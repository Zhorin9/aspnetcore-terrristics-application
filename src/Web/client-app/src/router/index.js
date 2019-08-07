import Vue from 'vue';
import Router from 'vue-router';

import TheHomePage from '../components/TheHomePage.vue';
import LoginPage from '../components/user/LoginPage.vue';
import TheUserWindow from "../components/TheUserWindow";
import ThePublicWindow from "../components/ThePublicWindow";

Vue.use(Router);

export const router = new Router({
    routes: [
        {
            path: '/',
            name: 'TheHome',
            component: TheHomePage,
        },
        {
            path: '/mojeOkna',
            name: 'TheUserWindow',
            component: TheUserWindow,
        },
        {
            path: '/okna',
            name: 'ThePublicWindow',
            component: ThePublicWindow,
        },
        {
            path: '/zaloguj',
            name: 'LoginPage',
            component: LoginPage,
        },
    ],
});
