<template>
    <nav>
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css">
        <b-navbar toggleable="lg" type="dark" class="nav-green">
            <b-navbar-brand active class="navbar-brand" to="/">
                Moje Terrarium <i class="fas fa-frog"></i>
            </b-navbar-brand>
            <b-navbar-nav>
                <b-nav-item :to="{name: 'ThePublicWindow'}">Publiczne terraria</b-nav-item>
                <b-nav-item :to="{name: 'TheUserWindow'}">Moje terraria</b-nav-item>
            </b-navbar-nav>

            <b-navbar-nav v-if="loggedIn" class="ml-auto">
                <b-nav-item-dropdown right>
                    <template slot="button-content">{{getUserEmail}}</template>
                    <b-dropdown-item :to="{name: 'TheHomePage'}">
                        Costam
                    </b-dropdown-item>
                    <b-dropdown-item @click="logOut">Wyloguj</b-dropdown-item>
                </b-nav-item-dropdown>
            </b-navbar-nav>

            <b-navbar-nav v-else class="ml-auto">
                <b-nav-item right :to="{name: 'LoginPage'}">Zaloguj</b-nav-item>
                <b-nav-item right to="/RegisterPage">Zarejestruj się</b-nav-item>
            </b-navbar-nav>

        </b-navbar>
    </nav>
</template>

<script>
    import types from "../store/types";
    import {mapGetters} from "vuex";

    export default {
        computed: {
            ...mapGetters({
                loggedIn: types.getters.AUTHENTICATION_IS_USER_LOGGED_CORRECT,
                getUserEmail: types.getters.AUTHENTICATION_GET_CURRENT_USER
            }),
        },
        methods: {
            logOut() {
                this.$store.commit(types.mutations.AUTHENTICATION_LOGOUT);
                this.$route.push({
                    name: 'HomePage'
                });
            },
        }
    };
</script>

<style scoped>
    .nav-green {
        background-image: linear-gradient(30deg, #040E0D, #1E6036);
    }

    .b-nav-dropdown {
        background-color: #1a5330;
        border-radius: 5px;
        border: #204619 1px solid;
    }

    .dropdown-item {
        color: #fff;
        text-decoration: none;
    }

    .dropdown-item:hover, .dropdown-item:focus {
        background-color: #164629 !important;
    }

    .dropdown-item.active {
        color: #fff;
        background-color: #0e2d1d !important;
        opacity: 0.5;
    }
</style>
