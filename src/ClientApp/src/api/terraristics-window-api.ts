import axios from 'axios';
import {endpoints} from "@/api/endpoints";
import {getHeaderWithJwtToken} from "@/api/header-generator";

class TerraristicsWindowApiImpl implements TerraristicsWindowApi {
    getTerraristicsWindows(): Promise<any> {
        return axios.get(endpoints.getTerraristicsWindows,
            {
                headers: getHeaderWithJwtToken(),
            })
    }

    createNewTerraristicsWindow(request: any): Promise<any> {
        return axios.post(endpoints.createNewTerraristicsWindow,
            request,
            {
                headers: getHeaderWithJwtToken()
            });
    }

    updateTerraristicsWindow(request: TerraristicsWindowFormData): Promise<any> {
        return axios.post(endpoints.updateTerraristicsWindow,
            request,
            {
                headers: getHeaderWithJwtToken()
            });
    }
}

export const terraristicsWindowApiImpl = new TerraristicsWindowApiImpl();