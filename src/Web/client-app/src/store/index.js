import Vue from 'vue';
import Vuex from 'vuex';

import { authentication } from './authentication.module';
import { users } from './users.module';
import { alert } from './alert.module';

Vue.use(Vuex);

export const store = new Vuex.Store({
    modules: {
        authentication,
        users,
        alert
    }
});