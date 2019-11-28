import {endpoints} from "@/api/endpoints";
import axios from 'axios';
import {getHeader} from "@/api/header-generator";

class UserApiImpl implements UserApi {
    login(email: string, password: string) {
        const header = getHeader();
        return axios.post(endpoints.getJwtToken,
            {Email: email, Password: password}, {headers: header});
    }
}

export const userApiImpl = new UserApiImpl();