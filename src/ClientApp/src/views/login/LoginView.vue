<template>
    <login/>
</template>

<script lang="ts">

    import {Component, Vue} from "vue-property-decorator";
    import Login from "@/views/login/components/Login.vue";

    @Component({
        components: {
            Login
        }
    })
    export default class LoginView extends Vue{
    };
</script>
