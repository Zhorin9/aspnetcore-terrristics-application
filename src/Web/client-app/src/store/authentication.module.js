import {userService} from '../services/user.service';
import types from "./types";

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
    }
};

const actions = {
    [types.actions.AUTHENTICATION_LOGIN]({dispatch, commit}, user) {
        commit(types.mutations.AUTHENTICATION_UPDATE_LOG_PROCESS);

        userService.login(user.email, user.password)
            .then(
                user => {
                    console.log(user);
                    commit(types.mutations.AUTHENTICATION_SET_STATE_TO_LOGGED);
                    commit(types.mutations.AUTHENTICATION_UPDATE_CURRENT_USER, user);
                },
            ).catch(
            error => {
                commit(types.mutations.ALERT_FAILED_LOGIN, {
                    Type: "LOGIN_FAILURE",
                    Message: "Nie udało się zalogować"
                });
            }
        )
    },
    [types.actions.AUTHENTICATION_LOGOUT]({commit}) {
        userService.logout();
        commit(types.mutations.AUTHENTICATION_LOGOUT);
    }
};

const mutations = {
    [types.mutations.AUTHENTICATION_UPDATE_LOG_PROCESS]() {
        state.LogProcess = true;
    },
    [types.mutations.AUTHENTICATION_LOGOUT]() {
        state.Email = "";
        state.Token = "";
        state.TokenExpiration = "";
        state.LogProcess = false;
        state.LoggedCorrect = false;
    },
    [types.mutations.AUTHENTICATION_SET_STATE_TO_LOGGED]() {
        state.LoggedCorrect = true;
        state.LogProcess = false;
    },
    [types.mutations.AUTHENTICATION_UPDATE_CURRENT_USER](state, user) {
        state.Token = user.Token;
        state.TokenExpiration = user.TokenExpiration;
        state.LoggedCorrect = true;
    },
};

export default {
    actions,
    state,
    mutations,
    getters
};
