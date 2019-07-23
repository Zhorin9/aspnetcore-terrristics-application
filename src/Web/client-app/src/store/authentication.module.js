import {userService} from '../services/user.service';
import types from "./types";
import {router} from '../router/index.js';

const state = {
    LogProcess: false,
    LoggedCorrect: false,
    Email: "",
    Token: "",
    TokenExpiration: ""
};

const getters = {
    [types.getters.AUTHENTICATION_GET_CURRENT_USER](state, payload) {
        return state.Email;
    },
    [types.getters.AUTHENTICATION_IS_USER_LOGGED_CORRECT]() {
        return state.LoggedCorrect;
    },
    [types.getters.AUTHENTICATION_IS_LOG_PROCESS](){
        return state.LogProcess;
    }
};

const actions = {
    [types.actions.AUTHENTICATION_LOGIN]({dispatch, commit}, user) {
        commit(types.mutations.AUTHENTICATION_UPDATE_LOG_PROCESS, user.email);

        userService.login(user.email, user.password)
            .then(
                user => {
                    commit(types.mutations.AUTHENTICATION_SET_STATE_TO_LOGGED);
                    commit(types.mutations.AUTHENTICATION_UPDATE_CURRENT_USER, user);

                    router.push({
                        name: 'HomePage'
                    });
                },
            ).catch(
            () => {
                commit(types.mutations.AUTHENTICATION_LOGIN_FAILED);
                //TODO commit(types.mutations.ALERT_FAILED_LOGIN, {
                //     Type: "LOGIN_FAILURE",
                //     Message: "Nie udało się zalogować"
                // });
            }
        )
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
        state.Token = "";
        state.TokenExpiration = "";
        state.LogProcess = false;
        state.LoggedCorrect = false;
    },
    [types.mutations.AUTHENTICATION_SET_STATE_TO_LOGGED]: state => {
        state.LoggedCorrect = true;
        state.LogProcess = false;
    },
    [types.mutations.AUTHENTICATION_UPDATE_CURRENT_USER](state, user) {
        state.Token = user.Token;
        state.TokenExpiration = user.TokenExpiration;
        state.LoggedCorrect = true;
    },
    [types.mutations.AUTHENTICATION_LOGIN_FAILED]: state => {
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
