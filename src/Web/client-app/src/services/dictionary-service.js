import axios from 'axios';
import endpoints from "../utils/endpoints";
import {GetHeaderWithJwtToken} from "../helpers/auth-helper";

export const dictionaryService = {
    getSensorKindsDict,
};

function getSensorKindsDict() {
    let headerWithJwtToken = GetHeaderWithJwtToken();

    return axios.get(endpoints.getSensorKinds, {headers: headerWithJwtToken})
        .then(response => {
            return response.data;
        })
        .catch(err => {
            console.error("Sensor list could not be retrieved.", err.message);
        })
}
