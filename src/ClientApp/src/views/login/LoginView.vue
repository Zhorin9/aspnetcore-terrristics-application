<template>
    <login-page/>
</template>

<script lang="ts">

    import {Component, Vue} from "vue-property-decorator";
    import LoginPage from "../../components/LoginPage.vue";

    @Component({
        components: {
            LoginPage
        }
    })
    export default class LoginView extends Vue{
    };
</script>
