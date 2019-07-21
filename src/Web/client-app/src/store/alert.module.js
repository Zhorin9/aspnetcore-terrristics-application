import types from "./types";

const state = {
    FailedLogin: {}
};

const getters = {

};

const mutations = {
    [types.mutations.ALERT_FAILED_LOGIN](state, payload){
        state.FailedLogin = payload.value;
    },
    [types.mutations.ALERT_SUCCESS_LOGIN](){
        state.FailedLogin = {};
    },
};

export default {
    state,
    getters,
}

export const alert = {
    namespaced: true,
    state: {
        type: null,
        message: null
    },
    actions: {
        success({ commit }, message) {
            commit('success', message);
        },
        error({ commit }, message) {
            commit('error', message);
        },
        clear({ commit }, message) {
            commit('success', message);
        }
    },
    mutations: {
        success(state, message) {
            state.type = 'alert-success';
            state.message = message;
        },
        error(state, message) {
            state.type = 'alert-danger';
            state.message = message;
        },
        clear(state) {
            state.type = null;
            state.message = null;
        }
    }
}
