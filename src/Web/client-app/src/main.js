import Vue from 'vue';

import { store } from '../src/store';
import { router } from '../src/router'

import BootstrapVue from 'bootstrap-vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

import axios from 'axios';
import App from './App.vue';

//Install Vue bootstrap extension
Vue.use(BootstrapVue);
Vue.config.productionTip = false;

//Set global validation message component
import ValidationMessages from "./components/common/ValidationMessages";
Vue.component('validation-messages', ValidationMessages);

//Register multiselect globally
import {Multiselect} from "vue-multiselect";
Vue.component('multiselect', Multiselect);

//Set vee-validate
import VeeValidate, { Validator } from 'vee-validate';
import pl from 'vee-validate/dist/locale/pl';
Vue.use(VeeValidate);
Validator.localize('pl', pl);

// Setup axios as the Vue default $http library
axios.defaults.baseURL = 'http://localhost:5000';
Vue.prototype.$http = axios;

new Vue({
  render: h => h(App),
  router,
  store,
}).$mount('#app');
