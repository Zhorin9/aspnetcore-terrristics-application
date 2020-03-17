import Vue from 'vue';
import App from './App.vue';

import 'normalize.css'

import { library } from '@fortawesome/fontawesome-svg-core'
import {faPlus} from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

library.add(faPlus)

Vue.component('font-awesome-icon', FontAwesomeIcon)

//Register multiselect globally
import {Multiselect} from "vue-multiselect";
Vue.component('multiselect', Multiselect);

Vue.config.productionTip = true;

// Setup bootstrap Vue
import BootstrapVue from 'bootstrap-vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

Vue.use(BootstrapVue);

import router from "@/router";
import store from '@/store'

import {ValidationProvider} from "vee-validate";
Vue.component('validation-provider', ValidationProvider);

// Setup axios as the Vue default $http library
import axios from 'axios';

import VueMoment from 'vue-moment';
Vue.use(VueMoment);

axios.defaults.baseURL = 'http://localhost:5000';
Vue.prototype.$http = axios;

new Vue({
    store,
    router,
    render: h => h(App)
}).$mount('#app');
