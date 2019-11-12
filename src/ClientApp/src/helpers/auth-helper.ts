import _ from 'lodash';

class HeaderImpl implements Header {
    readonly header: object;

    constructor() {
        this.header = {
            "Access-Control-Allow-Origin": '*',
            "Content-Type": 'application/json',
        };
    }

    GetHeader() : object {
        return this.header;
    }

    GetHeaderWithJwtToken(): object {
        let localStorageUser = localStorage.getItem('user');
        if (localStorageUser != null) {
            let user = JSON.parse(localStorageUser);

            if (user && user.Token) {
                let headerWithJwtToken = _.clone(this.header);
                headerWithJwtToken = _.extend(headerWithJwtToken,
                    {
                        "Authorization": "Bearer " + user.Token
                    });
                return headerWithJwtToken;
            }
        }
        return this.header;
    }
}

export const headerImpl = new HeaderImpl();

