import {userService} from '../../services/user-service';
import types from "../types";
import {router} from '../../router/index.js';

const userKey = "user";

const state = {
    Email: "",
    LogProcess: false
    //TODO Probably need to extend to some claims
};

const getters = {
    [types.getters.AUTHENTICATION_GET_CURRENT_USER]: state => {
        return state.Email;
    },
    [types.getters.AUTHENTICATION_IS_LOG_PROCESS]() {
        return state.LogProcess;
    },
    [types.getters.AUTHENTICATION_GET_JWT_TOKEN]() {
        let user = JSON.parse(localStorage.getItem(userKey));
        if(user){
            return user.Token;
        }
        return null;
    }
};

const actions = {
    [types.actions.AUTHENTICATION_LOGIN]({dispatch, commit}, user) {
        commit(types.mutations.AUTHENTICATION_UPDATE_LOG_PROCESS, user.email);

        return userService.login(user.email, user.password)
            .then(
                user => {
                    localStorage.setItem( JSON.stringify(user));
                    commit(types.mutations.AUTHENTICATION_SET_STATE_TO_LOGGED);

                    router.push({
                        name: 'HomePage'
                    });
                },
            ).catch(err => {
                commit(types.mutations.AUTHENTICATION_LOGIN_FAILED);
                console.error("Problem with authentication", err);
            })
    },
    [types.actions.AUTHENTICATION_LOGOUT]({commit}) {
        userService.logout();
        commit(types.mutations.AUTHENTICATION_LOGOUT);
    }
};

const mutations = {
    [types.mutations.AUTHENTICATION_UPDATE_LOG_PROCESS](state, email) {
        state.LogProcess = true;
        state.Email = email;
    },
    [types.mutations.AUTHENTICATION_LOGOUT]: state => {
        state.Email = "";
        state.LogProcess = false;
        state.LoggedCorrect = false;
    },
    [types.mutations.AUTHENTICATION_SET_STATE_TO_LOGGED]: state => {
        state.LoggedCorrect = true;
        state.LogProcess = false;
    },
    [types.mutations.AUTHENTICATION_LOGIN_FAILED]: state => {
        state.Email = "";
        state.LogProcess = false;
        state.LoggedCorrect = false;
    }
};

export default {
    actions,
    state,
    mutations,
    getters
};
