<template>
    <div>
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css">
        <section class="p-3">
            <i class="fas fa-frog fa-2x"> Moje terrarium</i>
        </section>
        <nav>
            <router-link :to="{name: 'ThePublicWindow'}">Publiczne terraria</router-link>
            <router-link :to="{name: 'TheUserWindow'}">Moje terraria</router-link>
            <template v-if="isUserLoggedIn">
                <router-link to="/RegisterPage" class="float-right">Zarejestruj się</router-link>
                <router-link :to="{name: 'LoginPage'}" class="float-right">Zaloguj się </router-link>
            </template>
            <template v-else>
                <router-link :to="{name: 'TheUserWindow'}" class="float-right">{{getUserEmail}}</router-link>
            </template>
        </nav>
    </div>
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
            isUserLoggedIn(){
                return !this.getUserEmail;
            },
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
    .router-link-active {
        background: #397334;
        color: #ffffff !important;
    }

    .float-right{
        float: right;
    }

    a {
        padding: 12px 30px 11px;
    }

    a:hover {
        text-decoration: none;
        background-color: #397334;;
        color: #ffffff !important;
        cursor: pointer;
    }

    section {
        color: #ffffff;
        width: 100%;
        background-color: #397334;;
    }

    nav {
        display: inline-block;
        background-color: #e8f2d9;
        width: 100%;
    }

    nav a {
        display: inline-block;
        color: #4c4c4d !important;
        font-size: 17px;
        line-height: 1.5;
    }

    nav a:first-child {
        margin-left: 10%;
    }

    nav.home .home,
    nav.projects .projects,
    nav.services .services,
    nav.contact .contact {
        background-color: #e35885;
    }
</style>
