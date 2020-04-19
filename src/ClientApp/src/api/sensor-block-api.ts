import axios from 'axios';
import {endpoints} from "@/api/endpoints";
import {getHeaderWithJwtToken} from "@/utils/header-generator";

class SensorBlockApiImpl implements SensorBlockApi {
    getSensorBlock(sensorBlockId: number): Promise<any> {
        return axios.get(endpoints.getSensorBlocks,
            {
                params: {sensorBlockId: sensorBlockId},
                headers: getHeaderWithJwtToken()
            })
    }   
    
    getSensorBlocks(windowId: string): Promise<any> {
        return axios.get(endpoints.getSensorBlocks,
            {
                params: {windowId: windowId},
                headers: getHeaderWithJwtToken()
            })
    }

    async create(request: any): Promise<any> {
        return await axios.post(endpoints.createNewSensorBlock,
            request,
            {
                headers: getHeaderWithJwtToken()
            })
    }
}

export const sensorBlockApiImpl = new SensorBlockApiImpl();