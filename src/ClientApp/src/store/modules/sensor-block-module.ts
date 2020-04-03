import {Action, getModule, Module, Mutation, VuexModule} from "vuex-module-decorators";
import store from "@/store";
import {sensorBlockApiImpl} from "@/api/sensor-block-api";

export interface SensorBlockState {
    SensorBlocks: SensorBlockModel[];
}

@Module({dynamic: true, store, name: 'terraristicsModule'})
class SensorBlock extends VuexModule implements SensorBlockState {
    SensorBlocks: Array<SensorBlockModel> = Array(0);

    @Mutation
    UPDATE_SENSOR_BLOCKS(sensorBlocks: Array<SensorBlockModel>) {
        this.SensorBlocks = sensorBlocks;
    }    

    @Action
    GET_LIST(windowId: string) {
        return sensorBlockApiImpl.getSensorBlocks(windowId)
            .then(response => {
                this.UPDATE_SENSOR_BLOCKS(response.data.Value);
                return true;
            })
            .catch(err => {
                console.error(err);
            });
    }
}

export const SensorBlockModule = getModule(SensorBlock);