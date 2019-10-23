import Vue from 'vue';
import Vuex from 'vuex';

import authentication from './modules/authentication-module';
import users from './modules/users-module';
import alert from './modules/alert-module';

Vue.use(Vuex);

export const store = new Vuex.Store({
    modules: {
        authentication,
        users,
        alert
    }
});
