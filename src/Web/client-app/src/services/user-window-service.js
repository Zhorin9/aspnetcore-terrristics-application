import axios from "axios";
import endpoints from "../utils/endpoints";
import {authHeader} from "../helpers/auth.header";

export const userWindowService = {
    addNewWindow
};

function addNewWindow(windowToCreate) {
    let header = authHeader();
    return axios.post(endpoints.createNewUserWindow, {windowToCreate}, {headers: header});
}
