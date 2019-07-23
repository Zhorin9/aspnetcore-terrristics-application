<template>
    <div class="col-3 d-block p-5 login-container">
        <div v-if="!waitingForResponse">
            <h2>Zaloguj się</h2>
            <form @submit.prevent="handleSubmit">
                <div class="text-left text-danger" v-if="!loggedCorrect && submitted">
                    <div>Nie udało się zalogować</div>
                    <div>Sprawdź czy wprowadziłeś poprawne dane</div>
                </div>
                <div class="form-groups form-label">
                    <label>Adres e-mail </label>
                    <input
                        v-model="email"
                        v-validate="'required|email'"
                        data-vv-as="Adres Email"
                        name="login.email"
                        class="form-control"
                        :class="{ 'is-invalid': errors.collect('login.email').length > 0 }"/>
                    <validation-messages :errors-list="errors.collect('login.email')"/>
                </div>
                <div class="form-group form-label">
                    <label>Hasło</label>
                    <input v-model="password"
                           v-validate="'required'"
                           data-vv-as="Hasło"
                           type="password"
                           name="login.password"
                           class="form-control"
                           :class="{ 'is-invalid': errors.first('login.password') }"/>
                    <validation-messages :errors-list="errors.collect('login.password')"/>
                </div>
                <div class="form-group">
                    <button type="submit" class="btn btn-green" :disabled="isDisabled">Zaloguj się</button>
                </div>
                <div class="form-group">
                    <router-link to="/register" class="btn btn-green router-left">Zarejestruj
                    </router-link>
                </div>
            </form>
        </div>
        <div v-else>
            <loading-page/>
        </div>
    </div>
</template>

<script>
    import types from "../../store/types";
    import {mapGetters} from "vuex";
    import LoadingPage from "../common/LoadingPage";

    export default {
        name: 'LoginPage',
        components: {
            LoadingPage
        },
        data() {
            return {
                email: "",
                password: "",
                submitted: false
            };
        },
        computed: {
            ...mapGetters(
                {
                    loggedCorrect: types.getters.AUTHENTICATION_IS_USER_LOGGED_CORRECT,
                    waitingForResponse: types.getters.AUTHENTICATION_IS_LOG_PROCESS,
                }
            ),
            isDisabled() {
                return !this.password ||
                    !this.email;
            }
        },
        created() {
            this.$store.dispatch(types.actions.AUTHENTICATION_LOGOUT);
        },
        methods: {
            handleSubmit(e) {
                const {email, password} = this;
                if (email && password) {
                    this.$store.dispatch(types.actions.AUTHENTICATION_LOGIN, {email, password});
                    this.submitted = true;
                }
            }
        }
    }
</script>

<style scoped>
    .login-container {
        padding: 20px;
        color: #fff;
    }

    .form-label {
        text-align: left;
        margin-top: 8px;
        font-weight: bold;
    }

    .form-control {
        background-color: #081b14;
        border-left: 3px solid #5b8111;
        border-right: none;
        border-top: none;
        border-bottom: 1px solid #5b8111;
    }

    .form-control:focus {
        color: #fff;
        background-color: #1f2d0f9c;
        border-color: #316849;
        outline: 0;
        -webkit-box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.25);
        box-shadow: 0 0 0 0.2rem rgba(37, 123, 28, 0.25);
    }

    .btn-green {
        display: block;
        color: #fff;
        background-color: #061611;
        border-color: #5b8111;
    }

    .btn-green:disabled {
        display: block;
        color: #fff;
        background-color: #061611;
        border-color: #27350d;;
    }

    .router-left {
        float: left;
    }
</style>


