import axios from 'axios';
import {GetHeaderWithJwtToken} from "./service-helper";
import endpoints from "../utils/endpoints";

export const dictionaryService = {
    getSensorKindsDict,
};

function getSensorKindsDict(token) {
    let headerWithJwtToken = GetHeaderWithJwtToken(token);

    return axios.get(endpoints.getSensorKinds, {headers: headerWithJwtToken})
        .then(response => {
            return response.data;
        })
        .catch(err => {
            console.error("Sensor list could not be retrieved.", err.message);
        })
}
