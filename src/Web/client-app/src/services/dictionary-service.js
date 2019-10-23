import axios from 'axios';
import {GetHeaderWithJwtToken} from "./service-helper";

export const dictionaryService = {
    getSensorKinds,
};

function getSensorKinds(token){
    let header = GetHeaderWithJwtToken(token);
}
