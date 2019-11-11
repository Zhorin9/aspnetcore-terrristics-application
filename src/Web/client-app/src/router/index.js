import Vue from 'vue';
import Router from 'vue-router';

import TheHomePage from '../components/TheHomePage.vue';
import LoginPage from '../components/user/LoginPage.vue';
import TheTerraristicsWindows from "../components/TheTerraristicsWindows";
import ThePublicWindow from "../components/ThePublicWindow";
import TerraristicsWindowData from "../components/terraristicsWindow/TerraristicsWindowData";

Vue.use(Router);

export const router = new Router({
    routes: [
        {
            path: '/',
            name: 'TheHomePage',
            component: TheHomePage,
        },
        {
            path: '/mojeOkna',
            name: 'TheTerraristicsWindows',
            component: TheTerraristicsWindows,
        },
        {
          path: '/mojeOkna/:id',
            name: 'TerraristicsWindowData',
            component: TerraristicsWindowData
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
