import Vue from 'vue'
import Router, {RouteConfig} from 'vue-router'

Vue.use(Router);
import AuthRequired from '@/router/auth-required';

export const constantRoutes: RouteConfig[] = [
    {
        path: '/',
        component: () => import('@/views/home/HomeView.vue'),
        name: 'HomeView'
    },
    {
        path: '/userTerraristicWindows',
        name: 'userTerraristicWindows',
        beforeEnter: AuthRequired,
        component: () => import(/* webpackChunkName: "login" */ '@/views/userTerraristicsWindow/UserTerraristicsWindowView.vue'),
    },
    {
        path: '/terraristicsData/:id',
        name: 'terraristicsData',
        beforeEnter: AuthRequired,
        component: () => import(/* webpackChunkName: "login" */ '@/views/terraristicsWindow/TerraristicsWindowView.vue'),
        props: true
    },
    {
        path: '/login',
        component: () => import(/* webpackChunkName: "login" */ '@/views/login/LoginView.vue'),
    },
    {
        path: '/publicWindows',
        component: () => import(/* webpackChunkName: "login" */ '@/views/publicWindow/PublicWindowView.vue')
    },
];

const createRouter = () => new Router({
    linkActiveClass: 'active',
    // mode: 'history',  // Disabled due to Github Pages doesn't support this, enable this if you need.
    // scrollBehavior: (to, from, savedPosition) => {
    //     if (savedPosition) {
    //         return savedPosition
    //     } else {
    //         return {x: 0, y: 0}
    //     }
    // },
    routes: constantRoutes
});

const router = createRouter();

export default router;
