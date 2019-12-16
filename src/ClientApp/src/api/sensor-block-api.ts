import axios from 'axios';
import {endpoints} from "@/api/endpoints";
import {getHeaderWithJwtToken} from "@/api/header-generator";

class SensorBlockApiImpl implements SensorBlockApi {
    getSensorBlocks(windowId: string): Promise<any> {
        return axios.get(endpoints.getSensorBlocks,
            {
                headers: getHeaderWithJwtToken()
            })
    }
}

export const sensorBlockApiImpl = new SensorBlockApiImpl();