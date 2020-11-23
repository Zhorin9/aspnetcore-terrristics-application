import {userApiImpl} from "@/api/user-api";
import {removeUser} from "@/utils/local-storage";

interface UserService {
    login(email: string, password: string) : void;
    logout() : void;
}

class UserServiceImpl implements UserService {
    login(email: string, password: string) {
        return userApiImpl.login(email, password)
            .then(response => {
                let data = response.data;
                if (data.token) {
                    return data;
                }
                return null;
            })
            .catch(err => {
                console.error(err);
                this.handleError(err);
            });
    }

    logout() {
        removeUser();
    }

    private handleError(data: any) {
        if (data.response.status === 401) {
            // auto logout if 401 response returned from api
            this.logout();
            location.reload(true);
        }
        const error = (data.response.data.message) || data.response.status;
        return Promise.reject(error);
    }
}

export const userServiceImpl = new UserServiceImpl();