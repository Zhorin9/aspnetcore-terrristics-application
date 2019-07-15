<template>
    <div class="col-3 d-block p-5 login-container">
        <h2>Zaloguj się</h2>
        <form @submit.prevent="handleSubmit">
            <li v-if="badLogin" class="text-left">Nie udało się zalogować</li>
            <li v-if="badLogin" class="text-left">Sprawdź czy wprowadziłeś poprawne dane</li>
            <div class="form-groups form-label">
                <label for="email">Adres e-mail</label>
                <input type="text" v-model="email" name="email" class="form-control" :class="{ 'is-invalid': submitted && errors.includes('email') }" />
                <div v-show="errors.includes('email') && email" class="invalid-feedback">Adres email jest niepoprawny.</div>
            </div>
            <div class="form-group form-label">
                <label htmlFor="password">Hasło</label>
                <input type="password" v-model="password" name="password" class="form-control" :class="{ 'is-invalid': submitted && !password }" />
                <div v-show="submitted && !password" class="invalid-feedback">Hasło jest wymagane</div>
            </div>
            <div class="form-group">
                <button type="submit" class="btn btn-green" :disabled="isDisabled">Zaloguj się</button>
            </div>
            <div class="form-group">
                <router-link to="/register" class="btn btn-green router-left">Zarejestruj</router-link>
            </div>
        </form>
    </div>
</template>

<script>
import { isEmail } from '../../helpers/validators';
import types from "../../store/types";

export default {
    name: 'LoginPage',
    data(){
        return {
            email: "",
            password: "",
            submitted: false,
            errors: [],
        };
    },
    computed: {
        isDisabled(){
            return !this.password ||
                !this.email;
        },
        badLogin () {
            this.$forceUpdate();
            return this.$store.state.alert.message;
        }
    },
    created () {
        // reset login status
        this.$store.dispatch(types.actions.AUTHENTICATION_LOGOUT);
    },
    methods: {
        handleSubmit(e) {
            this.submitted = true;

            if(this.validate()){
                return;
            }
            const { email, password } = this;
            if (email && password) {
                this.$store.dispatch(types.actions.AUTHENTICATION_LOGIN, { email, password });
            }
        },
        validate() {
            this.errors = [];
            if(!isEmail(this.email)){
                this.errors.push('email');
            }

            return this.errors.length;
        }
    }
}
</script>

<style scoped>
.login-container{
    padding: 20px;
    color: #fff;
}
.form-label{
    text-align: left;
    margin-top: 8px;
    font-weight: bold;
}
.form-control{
    background-color: #081b14;
}
.form-control:focus {
    color: #fff;
    background-color: #1f2d0f9c;
    border-color: #316849;
    outline: 0;
    -webkit-box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.25);
    box-shadow: 0 0 0 0.2rem rgba(37, 123, 28, 0.25);
}
.form-control.is-invalid {
    border: 2px solid #b42424;
    background-color: #081b14;
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
.router-left{
    float: left;
}
</style>


