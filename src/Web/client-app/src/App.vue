<template>
  <div id="app">
    <navigation/>
    <main>
      <router-view/>
    </main>
    <VueFooter/>
  </div>
</template>

<script>
import Navigation from './components/Navigation.vue';
import VueFooter from './components/VueFooter.vue';
export default {
  name: 'app',
  components: {
    Navigation,
    VueFooter
  },
};
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
.dropdown-menu {
  background-color:#336528 !important;
  border: 1px solid #009c1f!important;
}
html, 
body {
    height: 100%;
}
</style>
