import axios from 'axios';

export const userService = {
    login, 
    logout,
};

//Save current JwT Token in storage
function login(email, password){
    const headers = { 
        'Access-Control-Allow-Origin': '*',
        'Content-Type': 'application/json',    
    };
    return axios.post('/account/createToken',
            { Email: email, Password: password }, 
            { headers: headers })
        .then(data => {
            if(data.token){
                var user = { Email: email, Token: data.token, TokenExpiration: data.expiration}
                localStorage.setItem('user', JSON.stringify(user));
            }
            return user;
        })
        .catch(handleError);
}

//Remove user from local storage to log user out
function logout() {
    localStorage.removeItem('user');
}
function handleError(data){
    if(data.response.status === 401){
        // auto logout if 401 response returned from api
        logout();
        location.reload(true);
    }
    const error = (data.response.data.message) || data.response.status;
    return Promise.reject(error);
}