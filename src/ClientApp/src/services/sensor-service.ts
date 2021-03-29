import {sensorApiImpl} from "@/api/sensor-api";

interface SensorService {
    create(sensorBlock: SensorFormDialogModel): Promise<number>;

    update(sensorBlock: SensorFormDialogModel): Promise<number>;

    getList(windowId: number): Promise<SensorModel>;

    get(sensorId: number): Promise<SensorModel>;

    removeAllReadData(sensorBlockId: number): Promise<boolean | void>;
}

class SensorServiceImpl implements SensorService {
    async create(sensorBlock: SensorFormDialogModel) {
        return sensorApiImpl.create(sensorBlock)
            .then(response => {
                return response.data;
            })
            .catch(err => {
                console.error(err);
                throw err;
            })
    }

    async update(sensorBlock: SensorFormDialogModel) {
        return sensorApiImpl.update(sensorBlock)
            .then(response => {
                return response.data;
            })
            .catch(err => {
                console.error(err);
            })
    }

    async getList(windowId: number) {
        return sensorApiImpl.getSensors(windowId)
            .then(response => {
                return response.data.sensorBlocks;
            })
            .catch(err => {
                console.error(err);
            });
    }

    async get(id: number) {
        return sensorApiImpl.getSensor(id)
            .then(response => {
                return response.data;
            })
            .catch(err => {
                console.error(err);
            })

    }

    async removeAllReadData(sensorBlockId: number) {
        return await sensorApiImpl.removeAllInputData(sensorBlockId)
            .then(() => {
                return true;
            })
            .catch(err => {
                console.error(err);
            })
    }
}

export const sensorServiceImpl = new SensorServiceImpl();
