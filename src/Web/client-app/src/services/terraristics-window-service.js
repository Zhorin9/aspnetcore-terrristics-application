import axios from "axios";
import endpoints from "../utils/endpoints";
import {GetHeaderWithJwtToken} from "../helpers/auth-helper";

export const terraristicsWindowService = {
    addNewWindow
};

function addNewWindow(name, description) {
    let header = GetHeaderWithJwtToken();
    console.log(name);
    return axios.post(endpoints.createNewTerraristicsWindow,
        {
            "Name": name,
            "Description": description
        },
        {
            headers: header
        });
}
