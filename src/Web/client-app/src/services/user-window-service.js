import axios from "axios";
import endpoints from "../utils/endpoints";
import {GetHeader} from "./service-helper";

export const userWindowService = {
    addNewWindow
};

const addNewWindow = function(payload){
    return axios.post(endpoints.createNewUserWindow,
        {}, GetHeader)
};
