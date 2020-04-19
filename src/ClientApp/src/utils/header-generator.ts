import _ from "lodash";
import {getUserToken} from "@/utils/local-storage";

const header = {
    "Access-Control-Allow-Origin": '*',
    "Content-Type": 'application/json',
};

export const getHeader = () => header;
export const getHeaderWithJwtToken = () => {
    let userToken = getUserToken();
    if (userToken != null) {
        let headerWithJwtToken = _.clone(header);
        headerWithJwtToken = _.extend(headerWithJwtToken,
            {
                "Authorization": "Bearer " + userToken
            });
        return headerWithJwtToken;
    }
    return header;
};