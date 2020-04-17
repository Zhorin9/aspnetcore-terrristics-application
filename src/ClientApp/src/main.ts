import Vue from 'vue';
import App from './App.vue';

import 'normalize.css'

import {library} from '@fortawesome/fontawesome-svg-core'
import {faPlus} from '@fortawesome/free-solid-svg-icons'
import {FontAwesomeIcon} from '@fortawesome/vue-fontawesome'

library.add(faPlus);

Vue.component('font-awesome-icon', FontAwesomeIcon);

//Register multiselect globally
import {Multiselect} from "vue-multiselect";

Vue.component('multiselect', Multiselect);

Vue.config.productionTip = true;

// Setup bootstrap Vue
import BootstrapVue from 'bootstrap-vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

Vue.use(BootstrapVue);

import './configurations/vee-validate';
import router from "@/router";
import store from '@/store'

// Setup axios as the Vue default $http library
import axios from 'axios';

//Setup vue moment - used to date format https://github.com/brockpetrie/vue-moment?ref=madewithvuejs.com
import VueMoment from 'vue-moment';

Vue.use(VueMoment);

//Global comopnents
import LoadingPage from "@/components/common/LoadingPage.vue";
import ErrorPage from "@/components/common/ErrorPage.vue";
import SimpleDialog from "@/components/common/SimpleDialog.vue";

Vue.component('loading-page', LoadingPage);
Vue.component('error-page', ErrorPage);
Vue.component('simple-dialog', SimpleDialog);

axios.defaults.baseURL = process.env.VUE_APP_BASE_API;
Vue.prototype.$http = axios;

new Vue({
    store,
    router,
    render: h => h(App)
}).$mount('#app');
