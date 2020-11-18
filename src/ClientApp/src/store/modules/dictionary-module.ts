import {Action, getModule, Module, Mutation, VuexModule} from "vuex-module-decorators";
import store from "@/store";
import {dictionaryApiImpl} from "@/api/dictionary-api";
import {sensorTypes} from "@/utils/enums";
import _ from "lodash";

export interface DictionaryState {
    inputSensors: SensorKindModel[];
    outputSensors: SensorKindModel[];
}

@Module({dynamic: true, store, name: 'dictionaryModule'})
class Dictionary extends VuexModule implements DictionaryState {
    public inputSensors: SensorKindData[] = [];
    public outputSensors: SensorKindData[] = [];

    get DICT_GET_INPUT_SENSORS() {
        return this.inputSensors;
    }

    get DICT_GET_OUTPUT_SENSORS() {
        return this.outputSensors;
    }

    @Mutation
    public DICT_SET_INPUT_SENSORS(inputSensors: SensorKindData[]) {
        this.inputSensors = inputSensors;
    }

    @Mutation
    public DICT_SET_OUTPUT_SENSORS(outputSensors: SensorKindData[]) {
        this.outputSensors = outputSensors;
    }

    @Action
    public async DICT_GET_ALL_SENSOR_KINDS() {
        let inputSensors = Array(0);
        let outputSensors = Array(0);

        return await dictionaryApiImpl.getSensorKindsDict()
            .then(response => {
                    _.each(response.data, sensorKind => {
                        if (sensorKind.type === sensorTypes.input) {
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