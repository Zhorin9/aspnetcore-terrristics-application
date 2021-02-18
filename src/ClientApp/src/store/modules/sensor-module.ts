import {Action, getModule, Module, Mutation, VuexModule} from "vuex-module-decorators";
import store from "@/store";
import {sensorApiImpl} from "@/api/sensor-api";

export interface SensorState {
    sensors: SensorModel[];
}

@Module({dynamic: true, store, name: 'sensorModule'})
class Sensor extends VuexModule implements SensorState {
    sensors: Array<SensorModel> = Array(0);

    @Mutation
    UPDATE_SENSOR(sensorBlocks: Array<SensorModel>) {
        this.sensors = sensorBlocks;
    }

    @Action
    GET_LIST(windowId: string) {
        return sensorApiImpl.getSensors(windowId)
            .then(response => {
                debugger;

                this.UPDATE_SENSOR(response.data.sensorBlocks);
                return true;
            })
            .catch(err => {
                console.error(err);
            });
    }

    @Action
    async REMOVE_ALL_INPUT_DATA(sensorBlockId: string) {
        return await sensorApiImpl.removeAllInputData(sensorBlockId)
            .then(() => {
                return true;
            })
            .catch(err => {
                console.error(err);
            })
    }
}

export const SensorModule = getModule(Sensor);
