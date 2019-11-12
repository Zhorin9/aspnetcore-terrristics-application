import {headerImpl} from "@/helpers/auth-helper";
import {endpoints} from "@/api/endpoints";
import axios from 'axios';

class DictionaryApiImpl implements DictionaryApi {
    getSensorKindsDict(): Promise<SensorKind> {
        let headerWithJwtToken = headerImpl.GetHeaderWithJwtToken();
        return axios.get(endpoints.getSensorKinds, {headers: headerWithJwtToken});
    }
}

export const dictionaryApiImpl = new DictionaryApiImpl();