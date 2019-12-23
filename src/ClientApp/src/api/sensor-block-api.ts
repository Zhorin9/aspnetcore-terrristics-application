import axios from 'axios';
import {endpoints} from "@/api/endpoints";
import {getHeaderWithJwtToken} from "@/api/header-generator";

class SensorBlockApiImpl implements SensorBlockApi {
    getSensorBlocks(windowId: string): Promise<any> {
        debugger;
        return axios.get(endpoints.getSensorBlocks,
            {
                params: {windowId: windowId},
                headers: getHeaderWithJwtToken()
            })
    }
}

export const sensorBlockApiImpl = new SensorBlockApiImpl();