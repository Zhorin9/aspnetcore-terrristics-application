import _ from "lodash";

const header = {
    "Access-Control-Allow-Origin": '*',
    "Content-Type": 'application/json',
};

export const getHeader = () => header;
export const getHeaderWithJwtToken = () => {
    let localStorageUser = localStorage.getItem('user');
    if (localStorageUser != null) {
        let user = JSON.parse(localStorageUser);

        if (user && user.Token) {
            let headerWithJwtToken = _.clone(header);
            headerWithJwtToken = _.extend(headerWithJwtToken,
                {
                    "Authorization": "Bearer " + user.Token
                });
            return headerWithJwtToken;
        }
    }
    return header;
};

const generateHeaderWithJwtToken = function (): object {
    let localStorageUser = localStorage.getItem('user');
    if (localStorageUser != null) {
        let user = JSON.parse(localStorageUser);

        if (user && user.Token) {
            let headerWithJwtToken = _.clone(header);
            headerWithJwtToken = _.extend(headerWithJwtToken,
                {
                    "Authorization": "Bearer " + user.Token
                });
            return headerWithJwtToken;
        }
    }
    return header;
};