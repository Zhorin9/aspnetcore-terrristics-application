import Vue from 'vue';
import App from './App.vue';

Vue.config.productionTip = true;

// Setup axios as the Vue default $http library
import axios from 'axios';
axios.defaults.baseURL = 'http://localhost:5000';
Vue.prototype.$http = axios;

new Vue({
    render: h => h(App)
}).$mount('#app');
