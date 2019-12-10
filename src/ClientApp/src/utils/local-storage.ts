import _ from 'lodash';

// User
const userKey = 'vue_local_storage_user';
export const getUser = () => localStorage.getItem(userKey);
export const getUserEmail = () => JSON.parse(localStorage.getItem(userKey) || "").Email;
export const getUserToken = function () {
    let user = getUser();
    if (user === null) {
        return "";
    }
    return JSON.parse(user).Token;
};
export const setUser = (user: any) => localStorage.setItem(userKey, JSON.stringify(user));
export const removeUser = () => localStorage.removeItem(userKey);


// App
const sidebarStatusKey = 'sidebar_status'
export const getSidebarStatus = () => localStorage.getItem(sidebarStatusKey);
export const setSidebarStatus = (sidebarStatus: string) => localStorage.setItem(sidebarStatusKey, sidebarStatus);