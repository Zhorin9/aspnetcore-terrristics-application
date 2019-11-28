import axios from 'axios';
import {endpoints} from "@/api/endpoints";
import {getHeaderWithJwtToken} from "@/api/header-generator";

class TerraristicsWindowApiImpl implements TerraristicsWindowApi {
    addNewWindow(name: string, description: string): Promise<any> {
        return axios.post(endpoints.createNewTerraristicsWindow,
            {
                "Name": name,
                "Description": description
            },
            {
                headers: getHeaderWithJwtToken
            });
    }
}

export const terraristicsWindowApiImpl = new TerraristicsWindowApiImpl();