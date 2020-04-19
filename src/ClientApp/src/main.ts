import Vue from 'vue';
import App from './App.vue';

import 'normalize.css';

//Register multiselect globally
import {Multiselect} from "vue-multiselect";

Vue.component('multiselect', Multiselect);

Vue.config.productionTip = true;

// Setup bootstrap Vue
import BootstrapVue from 'bootstrap-vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

Vue.use(BootstrapVue);

import router from "@/router";
import store from '@/store'

//Setup vue moment - used to date format https://github.com/brockpetrie/vue-moment?ref=madewithvuejs.com
import VueMoment from 'vue-moment';
Vue.use(VueMoment);

// Initialize custom global components
import '@/configurations/global-components';

// Initialize vee-validate configuration with imported validators
import '@/configurations/vee-validate-config';

// Initialize axios https://github.com/axios/axios
import '@/configurations/axios-config';

// Initialize vue font awesome icons and global component
import '@/configurations/font-awesome-config';

new Vue({
    store,
    router,
    render: h => h(App)
}).$mount('#app');
