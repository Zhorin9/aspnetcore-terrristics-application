import Vue from 'vue';
import BootstrapVue from 'bootstrap-vue';
import App from './App.vue';
import router from './router';
import store from './store';
import axios from 'axios';

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

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
