import axios from 'axios';
import {endpoints} from "@/api/endpoints";
import {getHeaderWithJwtToken} from "@/api/header-generator";

class DictionaryApiImpl implements DictionaryApi {
    async getSensorKindsDict() {
        const header = getHeaderWithJwtToken();
        return await axios.get(endpoints.getSensorKinds, {headers: header});
    }
}

export const dictionaryApiImpl = new DictionaryApiImpl();