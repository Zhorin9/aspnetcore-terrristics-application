<template>
    <div class="col-3 d-block p-5 login-container m-5">
        <div v-if="!waitingForResponse">
            <h2>Zaloguj się</h2>
            <validation-observer ref="observer" v-slot="{ invalid }">
                <form @submit.prevent="handleSubmit">
                    <div class="text-left text-danger" v-if="submitted">
                        <div>Nie udało się zalogować</div>
                        <div>Sprawdź czy wprowadziłeś poprawne dane</div>
                    </div>
                    <div class="form-groups form-label">
                        <label>Adres e-mail </label>
                        <validation-provider rules="required|min:6" v-slot="{ errors }">
                            <input v-model="email"
                                   name="login.email"
                                   class="form-control"/>
                            <span>{{ errors[0] }}</span>
                            <span>{{errors[1]}}</span>
                        </validation-provider>
                    </div>
                    <div class="form-group form-label">
                        <label>Hasło</label>
                        <!--                    <input v-model="password"-->
                        <!--                           data-vv-as="Hasło"-->
                        <!--                           type="password"-->
                        <!--                           name="login.password"-->
                        <!--                           class="form-control"-->
                        <!--                           :class="{ 'is-invalid': errors.first('login.password') }"/>-->
                        <input v-model="password"
                               type="password"
                               class="form-control"/>
                    </div>
                    <div class="form-group">
                        <button type="submit" class="btn btn-green" :disabled="isDisabled">Zaloguj się
                        </button>
                    </div>
                    <div class="form-group">
                        <router-link to="/register" class="btn btn-green router-left">Zarejestruj
                        </router-link>
                    </div>
                </form>
            </validation-observer>
        </div>
        <div v-else>
            <loading-page/>
        </div>
    </div>
</template>

<script lang="ts">
    import _ from "lodash";
    import {AuthenticationModule} from "@/store/modules/authentication-module";
    import {Component, Vue} from "vue-property-decorator";
    import router from "@/router";

    @Component
    export default class LoginPage extends Vue {
        email: string = "";
        password: string = "";
        submitted: boolean = false;

        get waitingForResponse() {
            return AuthenticationModule.LogProcess;
        }

        get isDisabled() {
            return _.isNil(this.password) ||
                _.isNil(this.email);
        }

        created() {
            AuthenticationModule.LOGOUT();
        };

        async handleSubmit() {
            const isValid = await this.$refs.observer.validate();
            if (!isValid) {
                debugger;
                return;
            }

            debugger;
            const {email, password} = this;
            if (email && password) {
                this.submitted = true;
                await AuthenticationModule.LOGIN({Email: email, Password: password});
            }
        };
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


