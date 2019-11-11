import _ from 'lodash';

const header = {
    "Access-Control-Allow-Origin": '*',
    "Content-Type": 'application/json',
};

const GetHeader = function () {
    return header;
};

const GetHeaderWithJwtToken = function () {
    let user = JSON.parse(localStorage.getItem('user'));
    if(user && user.Token){
        let headerWithJwtToken = _.clone(header);
        headerWithJwtToken = _.extend(headerWithJwtToken,
            {
                "Authorization": "Bearer " + user.Token
            });
        return headerWithJwtToken;
    }
    else {
        return header;
    }
};

export {
    GetHeader,
    GetHeaderWithJwtToken,
};
