import {Action, getModule, Module, Mutation, VuexModule} from "vuex-module-decorators";
import store from "@/store";
import {sensorBlockApiImpl} from "@/api/sensor-block-api";

export interface SensorBlockState {
    sensorBlocks: SensorBlockModel[];
}

@Module({dynamic: true, store, name: 'sensorBlockModule'})
class SensorBlock extends VuexModule implements SensorBlockState {
    sensorBlocks: Array<SensorBlockModel> = Array(0);

    @Mutation
    UPDATE_SENSOR_BLOCKS(sensorBlocks: Array<SensorBlockModel>) {
        this.sensorBlocks = sensorBlocks;
    }

    @Action
    GET_LIST(windowId: string) {
        return sensorBlockApiImpl.getSensorBlocks(windowId)
            .then(response => {
                this.UPDATE_SENSOR_BLOCKS(response.data.sensorBlocks);
                return true;
            })
            .catch(err => {
                console.error(err);
            });
    }
    
    @Action
    async REMOVE_ALL_INPUT_DATA(sensorBlockId: string) {
        return await sensorBlockApiImpl.removeAllInputData(sensorBlockId)
            .then(() => {
                return true;
            })
            .catch(err => {
                console.error(err);
            })
    }
}

export const SensorBlockModule = getModule(SensorBlock);