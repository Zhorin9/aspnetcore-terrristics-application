import Vue from 'vue'

import 'normalize.css'
import ElementUI from 'element-ui';

import locale from 'element-ui/lib/locale/lang/en';
Vue.use(ElementUI, { locale })

import SvgIcon from 'vue-svgicon'

import '@/styles/element-variables.scss'
import '@/styles/index.scss'

import App from '@/App.vue'
import store from '@/store'
import router from "@/router/router";
import '@/icons/components'

//Setup vue moment - used to date format https://github.com/brockpetrie/vue-moment?ref=madewithvuejs.com
import VueMoment from 'vue-moment';
Vue.use(VueMoment);

import '@/router/permission'

// Initialize vee-validate configuration with imported validators
import '@/configurations/vee-validate-config';

// Initialize axios https://github.com/axios/axios
import '@/configurations/axios-config';

Vue.use(ElementUI)
Vue.use(SvgIcon, {
  tagName: 'svg-icon',
  defaultWidth: '1em',
  defaultHeight: '1em'
})

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: (h) => h(App)
}).$mount('#app')
