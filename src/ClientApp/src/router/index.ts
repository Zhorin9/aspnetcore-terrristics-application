import Vue from 'vue'
import Router, {RouteConfig} from 'vue-router'

Vue.use(Router);

export const constantRoutes: RouteConfig[] = [
    {
        path: '/',
        component: () => import('@/views/home/HomeView.vue'),
        name: 'HomeView',
        meta: {hidden: true}
    },
    {
        path: '/login',
        component: () => import(/* webpackChunkName: "login" */ '@/views/login/LoginView.vue'),
        meta: {hidden: true}
    },
    {
        path: '/publicWindows',
        component: () => import(/* webpackChunkName: "login" */ '@/views/public/PublicView.vue'),
        meta: {hidden: true}
    },
    {
        path: '/userTerraristicWindows',
        name: 'userTerraristicWindows',
        component: () => import(/* webpackChunkName: "login" */ '@/views/userTerraristicsWindow/UserTerraristicsWindowView.vue'),
        meta: {hidden: true}
    },
    {
        path: '/terraristicsData/:id',
        name: 'terraristicsData',
        component: () => import(/* webpackChunkName: "login" */ '@/views/terraristicsWindow/TerraristicsWindowView.vue'),
        meta: {hidden: true},
        props: true
    },
];

const createRouter = () => new Router({
    // mode: 'history',  // Disabled due to Github Pages doesn't support this, enable this if you need.
    scrollBehavior: (to, from, savedPosition) => {
        if (savedPosition) {
            return savedPosition
        } else {
            return { x: 0, y: 0 }
        }
    },
    routes: constantRoutes
});

const router = createRouter();

export default router;
