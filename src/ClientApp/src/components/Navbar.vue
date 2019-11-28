<template>
    <nav>
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css">
        <b-navbar toggleable="lg" type="dark" class="nav-green">
            <b-navbar-brand active class="navbar-brand" to="/">
                Moje Terrarium <i class="fas fa-frog"/>
            </b-navbar-brand>
            <b-navbar-nav>
                <b-nav-item to="/publicWindows">Publiczne terraria</b-nav-item>
                <b-nav-item :to="{name: 'TheTerraristicsWindows'}">Moje terraria</b-nav-item>
            </b-navbar-nav>

            <b-navbar-nav v-if="isLogged" class="ml-auto">
                <b-nav-item-dropdown right>
                    <template slot="button-content">{{getUserEmail}}</template>
                    <b-dropdown-item :to="{name: 'TheHomePage'}">
                        Costam
                    </b-dropdown-item>
                    <b-dropdown-item @click="logOut">Wyloguj</b-dropdown-item>
                </b-nav-item-dropdown>
            </b-navbar-nav>

            <b-navbar-nav v-else class="ml-auto">
                <b-nav-item right to="/login">Zaloguj</b-nav-item>
                <b-nav-item right to="/RegisterPage">Zarejestruj się</b-nav-item>
            </b-navbar-nav>
        </b-navbar>
    </nav>
</template>

<script lang="ts">
    import _ from 'lodash';
    import {Component, Vue} from "vue-property-decorator";
    import {AuthenticationModule} from "@/store/modules/authentication-module";

    @Component
    export default class Navbar extends Vue {
        get getUserEmail() {
            return AuthenticationModule.AUTHENTICATION_GET_EMAIL;
        }
        
        get isLogged() {
            return !_.isNil(this.getUserEmail) && !_.isEmpty(this.getUserEmail);
        }
        
        logOut() {
            AuthenticationModule.LOGOUT();
            this.$router.push({
                name: 'HomePage'
            });
        };
    }
</script>