import Vue from 'vue';
import axios,  {AxiosStatic} from 'axios';

declare module 'vue/types/vue' {
    interface Vue {
        axios: AxiosStatic;
    }
}

Vue.use({
    install() {
        Vue.prototype.axios = axios.create({
            baseURL: 'http://localhost:5000',
        });
    },
});

// Setup axios as the Vue default $http library
axios.defaults.baseURL = process.env.VUE_APP_BASE_API;
Vue.prototype.$http = axios;