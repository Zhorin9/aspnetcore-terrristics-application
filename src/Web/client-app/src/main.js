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

// Setup axios as the Vue default $http library
axios.defaults.baseURL = 'http://localhost:5000'
Vue.prototype.$http = axios

new Vue({
  render: h => h(App),
  router,
  store,
}).$mount('#app');
