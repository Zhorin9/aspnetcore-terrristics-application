import Vue from 'vue';
import LoadingPage from "@/components/common/LoadingPage.vue";
import ErrorPage from "@/components/common/ErrorPage.vue";
import SimpleDialog from "@/components/common/SimpleDialog.vue";

// Install loading page component
Vue.component('loading-page', LoadingPage);

// Install error page component
Vue.component('error-page', ErrorPage);

// Install simple yes/no dialog component
Vue.component('simple-dialog', SimpleDialog);