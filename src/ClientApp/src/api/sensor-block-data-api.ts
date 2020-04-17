import axios from 'axios';
import {endpoints} from "@/api/endpoints";
import {getHeaderWithJwtToken} from "@/api/header-generator";

class SensorBlockDataApiImpl implements SensorBlockDataApi {
    getList(sensorBlockId: number): Promise<any> {
        return axios.get(endpoints.getSensorBlockData,
            {
                params: {sensorBlockId: sensorBlockId},
                headers: getHeaderWithJwtToken()
            })
    }
}

export const sensorBlockDataApiImpl = new SensorBlockDataApiImpl();