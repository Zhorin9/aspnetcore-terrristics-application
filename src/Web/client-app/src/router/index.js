import Vue from 'vue';
import Router from 'vue-router';

import HomePage from '../components/HomePage.vue';
import TerraristicWindow from '../components/TerraristicWindow.vue';
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
      path: '/TerraristicWindow',
      name: 'TerraristicWindow',
      component: TerraristicWindow,
    },
    {
      path: '/LoginPage', 
      name: 'LoginPage',
      component: LoginPage,
    }
  ],
});

// router.beforeEach((to, from, next) => {
//   // redirect to login page if not logged in and trying to access a restricted page
//   const publicPages = ['/login', '/register'];
//   const authRequired = !publicPages.includes(to.path);
//   const loggedIn = localStorage.getItem('user');

//   if (authRequired && !loggedIn) {
//     return next('/login');
//   }

//   next();
// });