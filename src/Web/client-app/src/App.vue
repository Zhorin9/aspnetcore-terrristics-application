<template>
    <div id="app">
        <the-navigation/>
        <main>
            <router-view/>
        </main>
        <the-footer/>
    </div>
</template>

<script>
    import TheNavigation from './components/TheNavigation.vue';
    import TheFooter from './components/TheFooter.vue';

    export default {
        name: 'app',
        components: {
            TheNavigation,
            TheFooter
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
        background-color: #0e2d1d !important;
        border: 1px solid #071812 !important;
    }

    html,
    body {
        height: 100%;
        background-image: linear-gradient(80deg, #040E0D, #1E6036);
    }

    .form-control.is-invalid {
        border-left: 3px solid #b4241f;
        border-right: none;
        border-top: none;
        border-bottom: 1px solid #b4241f;
        background-image: none;
    }
</style>
