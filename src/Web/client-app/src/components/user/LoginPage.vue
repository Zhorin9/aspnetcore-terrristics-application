<template>
    <div class="col-6 d-block login-container">
        <h2>Zaloguj się</h2>
        <form @submit.prevent="handleSubmit">
            <div class="form-groups">
                <label for="email">Email</label>
                <input type="text" v-model="email" name="email" class="form-control" :class="{ 'is-invalid': submitted && errors.includes('email') }" />
                <div v-show="errors.includes('email')" class="invalid-feedback">Adres email jest niepoprawny.</div>
            </div>
            <div class="form-group">
                <label htmlFor="password">Password</label>
                <input type="password" v-model="password" name="password" class="form-control" :class="{ 'is-invalid': submitted && !password }" />
                <div v-show="submitted && !password" class="invalid-feedback">Hasło jest wymagane</div>
                <span v-show="errors.includes('password')" class="invalid-feedback"></span>
            </div>
            <div class="form-group">
                <button type="submit" class="btn btn-green" :disabled="isDisabled">Zaloguj się</button>
                <router-link to="/register" class="btn btn-green">Zarejestruj</router-link>
            </div>
        </form>
    </div>
</template>

<script>
import { isEmail } from '../../helpers/validators';

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
        loggingIn () {
            return this.$store.state.authentication.user;
        }
    },
    created () {
        // reset login status
        this.$store.dispatch('authentication/logout');
    },
    methods: {
        handleSubmit(e) {
            this.submitted = true;

            if(this.validate()){
                return;
            }
            const { email, password } = this;
            if (email && password) {
                this.$store.dispatch('authentication/login', { email, password });
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
.form-control{
    background-color: #081b14;
    margin: 5px 5px 5px 15%;
    width: 70%;
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
}

.btn-green {
    margin: 5px;
    color: #fff;
    background-color: #061611;
    border-color: #5b8111;
}
.btn-green:disabled {
    color: #fff;
    background-color: #061611;
    border-color: #27350d;;
}
</style>


