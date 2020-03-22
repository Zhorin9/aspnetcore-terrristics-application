import axios from 'axios';
import {endpoints} from "@/api/endpoints";
import {getHeaderWithJwtToken} from "@/api/header-generator";

class TerraristicsWindowApiImpl implements TerraristicsWindowApi {
    getList(): Promise<any> {
        return axios.get(endpoints.getTerraristicsWindows,
            {
                headers: getHeaderWithJwtToken(),
            })
    }

    create(request: any): Promise<any> {
        return axios.post(endpoints.createNewTerraristicsWindow,
            request,
            {
                headers: getHeaderWithJwtToken()
            });
    }

    update(request: TerraristicsWindowFormData): Promise<any> {
        return axios.post(endpoints.updateTerraristicsWindow,
            request,
            {
                headers: getHeaderWithJwtToken()
            });
    }
    
    delete(windowId: number): Promise<any> {
        return axios.post(endpoints.deleteTerraristicsWindow,
            windowId,
            {
                headers: getHeaderWithJwtToken()
            });
    }
}

export const terraristicsWindowApiImpl = new TerraristicsWindowApiImpl();