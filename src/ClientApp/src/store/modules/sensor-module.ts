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
    ADD_SENSOR(sensorBlock: SensorModel){
        this.sensors.push(sensorBlock);
    }

    @Mutation
    UPDATE_SENSORS(sensorBlocks: Array<SensorModel>) {
        this.sensors = sensorBlocks;
    }

    @Mutation
    UPDATE_SENSOR(sensorBlock: SensorModel){
        this.sensors.push(sensorBlock);
    }

    @Action
    async Create(sensorBlock: SensorFormDialogModel) : Promise<number>{
        return sensorApiImpl.create(sensorBlock)
            .then(response => {
                return response.data;
            })
            .catch(err => {
                console.error(err);
                throw err;
            })
    }

    @Action Update(sensorBlock: SensorFormDialogModel){
        return sensorApiImpl.update(sensorBlock)
            .then(response => {
                return response.data;
            })
            .catch(err => {
                console.error(err);
            })
    }

    @Action
    GET_LIST(windowId: number) {
        return sensorApiImpl.getSensors(windowId)
            .then(response => {
                this.UPDATE_SENSORS(response.data.sensorBlocks);
                return true;
            })
            .catch(err => {
                console.error(err);
            });
    }

    @Action
    GET(sensorId: number){
        return sensorApiImpl.getSensor(sensorId)
            .then(response => {
                this.ADD_SENSOR(response.data);
            })
            .catch(err => {
                console.error(err);
            })

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
