import Vue from 'vue';
import Router from 'vue-router';

import HomePage from '../components/HomePage.vue';
import TerraristicWindow from '../components/TerraristicWindow.vue';

Vue.use(Router);

export default new Router({
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
  ],
});
