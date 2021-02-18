import axios from 'axios';
import {endpoints} from "@/api/endpoints";
import {getHeaderWithJwtToken} from "@/utils/header-generator";

class SensorApiImpl implements SensorApi {
    getSensor(sensorId: number): Promise<any> {
        return axios.get(endpoints.getSensor,
            {
                params: {sensorId: sensorId},
                headers: getHeaderWithJwtToken()
            })
    }

    getSensors(windowId: string): Promise<any> {
        return axios.get(endpoints.getSensors,
            {
                params: {windowId: windowId},
                headers: getHeaderWithJwtToken()
            })
    }

    async create(request: any): Promise<any> {
        return await axios.post(endpoints.createNewSensor,
            request,
            {
                headers: getHeaderWithJwtToken()
            })
    }

    async update(request: any): Promise<any> {
        return await axios.post(endpoints.updateSensor,
            request,
            {
                headers: getHeaderWithJwtToken()
            })
    }

    async removeAllInputData(sensorBlockId: string): Promise<any> {
        return await axios.post(endpoints.removeSensorBlockAllInputData,
            sensorBlockId,
            {
                headers: getHeaderWithJwtToken()
            })
    }
}

export const sensorApiImpl = new SensorApiImpl();
