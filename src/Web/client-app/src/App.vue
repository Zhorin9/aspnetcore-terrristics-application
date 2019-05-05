<template>
  <div id="app">
    <main>
      <HomePage/>
    </main>
  </div>
</template>

<script>
import HomePage from './home/HomePage.vue';

export default {
  name: 'app',
  components: {
    HomePage,
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
  margin-top: 60px;
}
</style>
