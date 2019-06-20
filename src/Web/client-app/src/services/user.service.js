import axios from 'axios';
import { authHeader } from '../helpers/auth.header.js';

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
    axios.post('/account/createToken',
    { Email: email, Password: password }, 
    { headers: headers })
    .then(handleResponse)
    .then(user => {
        if(user.token){
            localStorage.setItem('user', JSON.stringify(user));
        }

        return user;
    });
}

//Remove user from local storage to log user out
function logout() {
    localStorage.removeItem('user');
}

function handleResponse(response){
    return response.text().then(text => {
        const data = text && JSON.parse(text);
        if (!response.ok) {
            if (response.status === 401) {
                // auto logout if 401 response returned from api
                logout();
                location.reload(true);
            }

            const error = (data && data.message) || response.statusText;
            return Promise.reject(error);
        }

        return data;
    });
}