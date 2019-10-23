import _ from "lodash";
import types from "../types";
import {dictionaryService} from "../../services/dictionary-service";
import {sensorType} from "../../enums/index";

const state = {
    InputSensors: Array(0),
    OutputSensors: Array(0),
};

const getters = {};

const mutations = {};

const actions = {
    [types.actions.DICT_GET_ALL_SENSOR_KINDS]({commit, getters, state}) {
        let jwtToken = getters[types.getters.AUTHENTICATION_GET_JWT_TOKEN];

        let inputSensors = Array(0);
        let outputSensors = Array(0);

        dictionaryService.getSensorKinds(jwtToken)
            .then(
                sensorKinds => {
                    _.each(sensorKinds, sensorKind => {
                        if(sensorKind.Type === sensorType.Input){
                            
                        }
                    })
                }
            )
            .catch(
                () => {

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
