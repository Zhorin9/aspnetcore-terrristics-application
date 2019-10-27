import _ from "lodash";
import types from "../types";
import {dictionaryService} from "../../services/dictionary-service";
import {sensorType} from "../../enums/index";

const state = {
    InputSensors: Array(0),
    OutputSensors: Array(0),
};

const getters = {
    [types.getters.DICT_GET_INPUT_SENSORS]: state => {
        return state.InputSensors;
    },
    [types.getters.DICT_GET_OUTPUT_SENSORS]: state => {
        return state.OutputSensors;
    }
};

const mutations = {
    [types.mutations.DICT_SET_INPUT_SENSORS](state, inputSensors) {
        state.InputSensors = inputSensors;
    },
    [types.mutations.DICT_SET_OUTPUT_SENSORS](state, outputSensors) {
        state.OutputSensors = outputSensors;
    }
};

const actions = {
    [types.actions.DICT_GET_ALL_SENSOR_KINDS]({commit, getters, state}) {
        let jwtToken = getters[types.getters.AUTHENTICATION_GET_JWT_TOKEN];
        let inputSensors = Array(0);
        let outputSensors = Array(0);

        return dictionaryService.getSensorKindsDict(jwtToken)
            .then(sensorKinds => {
                    _.each(sensorKinds, sensorKind => {
                        if (sensorKind.type === sensorType.Input) {
                            inputSensors.push(sensorKind);
                        } else {
                            outputSensors.push(sensorKind);
                        }
                    });
                    commit(types.mutations.DICT_SET_INPUT_SENSORS, inputSensors);
                    commit(types.mutations.DICT_SET_OUTPUT_SENSORS, outputSensors);
                }
            )
            .catch(err => {
                    console.error(err);
                }
            )
    }
};

export default {
    state,
    getters,
    mutations,
    actions
}
