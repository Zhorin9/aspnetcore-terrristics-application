import _ from 'lodash';

const header = {
    "Access-Control-Allow-Origin": '*',
    "Content-Type": 'application/json',
};

const GetHeader = function () {
    return header;
};

const GetHeaderWithJwtToken = function (jwtToken) {
    let headerWithJwtToken = _.clone(header);
    headerWithJwtToken = _.extend(headerWithJwtToken,
        {
            "Authorization": "Bearer " + jwtToken
        });
    return headerWithJwtToken;
};

export {
    GetHeader,
    GetHeaderWithJwtToken,
};
