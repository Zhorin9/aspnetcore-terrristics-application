<template>
    <nav>
        <b-navbar toggleable="lg" type="dark" class="nav-green">
            <b-navbar-brand active class="navbar-brand" to="/">
                Inteligentne terrarium  <font-awesome-icon :icon="['fas', 'frog']"/>
            </b-navbar-brand>
            <b-navbar-nav>
                <b-nav-item to="/publicWindows" right>Publiczne terraria</b-nav-item>
                <b-nav-item v-show="isUserAuthenticated" to="/userTerraristicWindows" right>Moje terraria</b-nav-item>
            </b-navbar-nav>

            <b-navbar-nav v-if="isUserAuthenticated" class="ml-auto">
                <b-nav-item-dropdown right>
                    <template slot="button-content">{{getUserEmail}}</template>
                    <b-dropdown-item to="/publicWindows">
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
    import {Component, Vue} from "vue-property-decorator";
    import {AuthenticationModule} from "@/store/modules/authentication-module";

    @Component
    export default class Navbar extends Vue {        
        get getUserEmail() {
            return AuthenticationModule.Email;
        }
        
        get isUserAuthenticated() {
            return AuthenticationModule.IsUserAuthenticated;
        }
        
        logOut() {
            AuthenticationModule.LOGOUT();
            this.$router.push({
                name: 'HomeView'
            });
        };
    }
</script>
<style>
    .nav-green{
        background-color: #113722;
    }
</style>