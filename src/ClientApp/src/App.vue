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
    import {DictionaryModule} from "@/store/modules/dictionary-module";

    @Component({
        components: {
            Navbar,
        }
    })
    export default class App extends Vue {
        created() {
            DictionaryModule.DICT_GET_ALL_SENSOR_KINDS();
        }
    }
</script>

<style>
    #app {
        font-family: 'Avenir', Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: white;
        background-color: #113722;
    }

    .dropdown-menu {
        background-color: #0e2d1d !important;
        border: 1px solid #071812 !important;
    }

    html,
    body {
        height: auto;
        background-color: #113722;
        color: white !important;
    }

    .form-control.is-invalid {
        border-left: 3px solid #b4241f;
        border-right: none;
        border-top: none;
        border-bottom: 1px solid #b4241f;
        background-image: none;
    }

    .btn-green {
        color: #fff;
        background-color: #061611;
        border-color: #5b8111;
    }

    .card-green {
        color: rgba(0, 0, 0, 0.5);
        text-align: left;
        padding-left: 0 !important;
        padding-right: 0 !important;
    }

    .bg-green {
        background-color: #85b262 !important;
    }

    .card-header-background {
        background: #85b262 !important;
    }

    .modal-header {
        background: #85b262 !important;
    }

    .modal-body {
        color: rgba(0, 0, 0, 0.5);
    }

    .cursor-pointer {
        cursor: pointer;
    }

    textarea {
        resize: none;
    }

    .height-fix-content {
        height: fit-content;
    }
</style>
