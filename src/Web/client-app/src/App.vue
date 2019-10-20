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
        color: #2c3e50;
        line-height: 1.47;
    }

    .dropdown-menu {
        background-color: #0e2d1d !important;
        border: 1px solid #071812 !important;
    }

    html,
    body {
        height: 100%;
        background-color: #ffffff;
    }

    .form-control.is-invalid {
        border-left: 3px solid #b4241f;
        border-right: none;
        border-top: none;
        border-bottom: 1px solid #b4241f;
        background-image: none;
    }
</style>
