import axios from 'axios';
import {endpoints} from "@/api/endpoints";
import {getHeaderWithJwtToken} from "@/utils/header-generator";

class TerrariumApiImpl implements TerrariumApi {
    getList(): Promise<any> {
        return axios.get(endpoints.getTerrariumList,
            {
                headers: getHeaderWithJwtToken(),
            })
    }

    get(terrariumId: number): Promise<any> {
        return axios.get(endpoints.getTerrarium,
            {
                params: {id: terrariumId},
                headers: getHeaderWithJwtToken(),
            })
    }

    create(request: TerrariumFormDialogModel): Promise<any> {
        return axios.post(endpoints.createNewTerrarium,
            request,
            {
                headers: getHeaderWithJwtToken()
            });
    }

    update(request: TerrariumFormDialogModel): Promise<any> {
        return axios.post(endpoints.updateTerrarium,
            request,
            {
                headers: getHeaderWithJwtToken()
            });
    }

    delete(windowId: number): Promise<any> {
        return axios.post(endpoints.deleteTerrarium,
            windowId,
            {
                headers: getHeaderWithJwtToken()
            });
    }
}

export const terrariumApiImpl = new TerrariumApiImpl();
