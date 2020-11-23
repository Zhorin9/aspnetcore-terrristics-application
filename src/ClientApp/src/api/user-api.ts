import {endpoints} from "@/api/endpoints";
import axios from 'axios';
import {getHeader} from "@/utils/header-generator";

class UserApiImpl implements UserApi {
    login(email: string, password: string) {
        const header = getHeader();
        return axios.post(endpoints.getJwtToken,
            {email, password}, 
            {headers: header, timeout: 3000});
    }
}

export const userApiImpl = new UserApiImpl();