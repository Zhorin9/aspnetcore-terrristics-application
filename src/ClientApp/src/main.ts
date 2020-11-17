import Vue from 'vue'

import 'normalize.css'
import ElementUI from 'element-ui'
import SvgIcon from 'vue-svgicon'

import '@/styles/element-variables.scss'
import '@/styles/index.scss'

import App from '@/App.vue'
import store from '@/store'
import router from "@/router/router";
import '@/icons/components'

import '@/router/permission'
// Initialize custom global components

import '@/configurations/global-components';
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
