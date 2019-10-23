import types from "../types";

const state = {
    FailedLogin: {}
};

const getters = {

};

const actions = {
    success({ commit }, message) {
        commit('success', message);
    },
    error({ commit }, message) {
        commit('error', message);
    },
    clear({ commit }, message) {
        commit('success', message);
    }
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
    mutations,
    actions
};
