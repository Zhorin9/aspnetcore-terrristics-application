import Vue from 'vue';
import axios, {AxiosStatic} from 'axios';

Vue.use({
    install() {
        Vue.prototype.axios = axios.create({
            baseURL: 'http://localhost:5000',
        });
    },
});

declare module 'vue/types/vue' {
    interface Vue {
        axios: AxiosStatic;
    }
}