<template>
    <div id="app">
        <navbar/>
        <main>
            <router-view/>
        </main>
    </div>
</template>

<script lang="ts">
    import {Component, Vue} from 'vue-property-decorator';
    import Navbar from "@/components/Navbar.vue";

    @Component({
        components: {
            Navbar,
        }
    })
    export default class App extends Vue {
    }
</script>

<style>
    #app {
        font-family: 'Avenir', Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: white;
    }

    .dropdown-menu {
        background-color: #0e2d1d !important;
        border: 1px solid #071812 !important;
    }

    html,
    body {
        height: 100%;
        background-image: linear-gradient(80deg, #040E0D, #1E6036);
        color: white !important;
    }

    .form-control.is-invalid {
        border-left: 3px solid #b4241f;
        border-right: none;
        border-top: none;
        border-bottom: 1px solid #b4241f;
        background-image: none;
    }

    .card-green {
        background: #204638 !important;
        text-align: left;
        padding-left: 0 !important;
        padding-right: 0 !important;
        color: white;
    }

    .card-header-background {
        background: #0a281d !important;
    }

    .modal-header {
        background: #0a281d !important;
    }

    .modal-content {
        background: #204638 !important;
    }

    textarea {
        resize: none;
    }
</style>
