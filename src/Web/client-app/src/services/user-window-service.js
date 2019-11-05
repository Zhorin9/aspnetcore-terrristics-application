import axios from "axios";
import endpoints from "../utils/endpoints";

export const userWindowService = {
    addNewWindow
};

const addNewWindow = function (windowToCreate) {
    return axios.post(endpoints.createNewUserWindow, {windowToCreate});
};
