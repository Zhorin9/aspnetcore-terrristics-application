import axios from 'axios';
import {endpoints} from "@/api/endpoints";
import {getHeaderWithJwtToken} from "@/utils/header-generator";

class SensorApiImpl implements SensorApi {
    getSensor(id: number): Promise<any> {
        return axios.get(endpoints.getSensor,
            {
                params: {id: id},
                headers: getHeaderWithJwtToken()
            })
    }

    getSensors(windowId: number): Promise<any> {
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

    async removeAllInputData(sensorBlockId: number) : Promise<any> {
        return await axios.post(endpoints.removeSensorBlockAllInputData,
            sensorBlockId,
            {
                headers: getHeaderWithJwtToken()
            })
    }
}

export const sensorApiImpl = new SensorApiImpl();
