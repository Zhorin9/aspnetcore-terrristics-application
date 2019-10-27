import axios from 'axios';
import {GetHeader} from "./service-helper";
import endpoints from "../utils/endpoints";

export const userService = {
    login,
    logout,
};

//Save current JwT Token in storage
function login(email, password) {
    return axios.post(endpoints.getJwtToken,
        {Email: email, Password: password}, GetHeader)
        .then(response => {
            let data = response.data;
            if (data.token) {
                return {Email: email, Token: data.token, TokenExpiration: data.expiration};
            }
        })
        .catch(handleError);
}

//Remove user from local storage to log user out
function logout() {

}

function handleError(data) {
    if (data.response.status === 401) {
        // auto logout if 401 response returned from api
        logout();
        location.reload(true);
    }
    const error = (data.response.data.message) || data.response.status;
    return Promise.reject(error);
}
