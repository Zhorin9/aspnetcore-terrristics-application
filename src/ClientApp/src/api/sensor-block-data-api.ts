import axios from 'axios';
import {endpoints} from "@/api/endpoints";
import {getHeaderWithJwtToken} from "@/utils/header-generator";

class SensorBlockDataApiImpl implements SensorBlockDataApi {
    getList(sensorBlockId: number): Promise<any> {
        return axios.get(endpoints.getSensorBlockData,
            {
                params: {sensorBlockId: sensorBlockId},
                headers: getHeaderWithJwtToken()
            })
    }

    getOutputState(sensorBlockId: number): Promise<any> {
        return axios.get(endpoints.getSensorBlockDataOutputState,
            {
                params: {sensorBlockId: sensorBlockId},
                headers: getHeaderWithJwtToken()
            })
    }

    async createOrUpdateSensorBlockData(request: any): Promise<any> {
        return await axios.post(endpoints.createOrUpdateSensorBlockData,
            request,
            {
                headers: getHeaderWithJwtToken()
            })
    }
}

export const sensorBlockDataApiImpl = new SensorBlockDataApiImpl();