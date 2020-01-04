import {Action, getModule, Module, Mutation, VuexModule} from "vuex-module-decorators";
import store from "@/store";
import {dictionaryApiImpl} from "@/api/dictionary-api";
import {sensorTypes} from "@/enums/sensor-types";
import _ from "lodash";

export interface DictionaryState {
    InputSensors: SensorKindModel[];
    OutputSensors: SensorKindModel[];
}

@Module({dynamic: true, store, name: 'dictionaryModule'})
class Dictionary extends VuexModule implements DictionaryState {
    public InputSensors: SensorKindData[] = [];
    public OutputSensors: SensorKindData[] = [];

    get DICT_GET_INPUT_SENSORS() {
        return this.InputSensors;
    }

    get DICT_GET_OUTPUT_SENSORS() {
        return this.OutputSensors;
    }

    @Mutation
    public DICT_SET_INPUT_SENSORS(inputSensors: SensorKindData[]) {
        this.InputSensors = inputSensors;
    }

    @Mutation
    public DICT_SET_OUTPUT_SENSORS(outputSensors: SensorKindData[]) {
        this.OutputSensors = outputSensors;
    }

    @Action
    public async DICT_GET_ALL_SENSOR_KINDS() {
        let inputSensors = Array(0);
        let outputSensors = Array(0);

        return await dictionaryApiImpl.getSensorKindsDict()
            .then(response => {
                    _.each(response.data, sensorKind => {
                        if (sensorKind.Type === sensorTypes.Input) {
                            inputSensors.push(sensorKind);
                        } else {
                            outputSensors.push(sensorKind);
                        }
                    });
                    this.DICT_SET_INPUT_SENSORS(inputSensors);
                    this.DICT_SET_OUTPUT_SENSORS(outputSensors);
                }
            )
            .catch(err => {
                    console.error(err);
                }
            )
    }
}

export const DictionaryModule = getModule(Dictionary);