import * as moment from 'moment';

// User
const userKey = 'vue_local_storage_user';
export const getUser = () => localStorage.getItem(userKey);
export const getUserEmail = function () {
    let user = getUser();
    if (user === null) {
        return '';
    }

    return JSON.parse(user || '').email;
};
export const getUserToken = function () {
    let user = getUser();
    if (user === null || user === 'undefined') {
        return '';
    }
    return JSON.parse(user).token;
};

export const isLoggedCorrect = function (): boolean {
    let user = getUser();
    if (user === null) {
        return false;
    }
    //@ts-ignore
    let tokenExpiration = moment(JSON.parse(user).tokenExpiration);
    //@ts-ignore
    let currentDate = moment();

    if (currentDate.diff(tokenExpiration, 'minutes') < 90) {
        return true;
    }
    removeUser();
    return false;
};

export const setUser = (user: any) => localStorage.setItem(userKey, JSON.stringify(user));
export const removeUser = () => localStorage.removeItem(userKey);

// App
const sidebarStatusKey = 'sidebar_status';
export const getSidebarStatus = () => localStorage.getItem(sidebarStatusKey);
export const setSidebarStatus = (sidebarStatus: string) => localStorage.setItem(sidebarStatusKey, sidebarStatus);