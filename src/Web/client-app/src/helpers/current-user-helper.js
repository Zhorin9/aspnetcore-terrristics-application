const userKey = "user";

export const getUserEmail = function () {
    let user = JSON.parse(localStorage.getItem(userKey));
    if (user) {
        return user.Email;
    }

    return null;
};

export const isUserLogged = function () {
    let user = JSON.parse(localStorage.getItem(userKey));
    return user !== null;
};
