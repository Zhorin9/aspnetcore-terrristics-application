import Vue from 'vue';
import Router from 'vue-router';

import HomePage from '../components/HomePage.vue';
import LoginPage from '../components/user/LoginPage.vue';

Vue.use(Router);

export const router = new Router({
  routes: [
    {
        path: '/',
        name: 'Home',
        component: HomePage,
    },
    {
      path: '/LoginPage',
      name: 'LoginPage',
      component: LoginPage,
    }
  ],
});
