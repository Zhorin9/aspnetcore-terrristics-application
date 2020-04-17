// Setup vee-validate globally https://logaretm.github.io/vee-validate/guide/basics.html#registering-the-validation-provider

import Vue from 'vue';
import {ValidationProvider, ValidationObserver, extend} from "vee-validate";
import {required, email, min, min_value, max, max_value} from 'vee-validate/dist/rules'

Vue.component('validation-provider', ValidationProvider);
Vue.component('validation-observer', ValidationObserver);

import {localize} from 'vee-validate';

const pl = require('vee-validate/dist/locale/pl.json');
pl.names = {
    email: 'e-mail',
    password: 'hasło',
    name: 'nazwa',
    description: 'opis'
};
localize('pl', pl);

// Install required rule and message
extend("required", required);

// Install email rule and message
extend("email", email);

// Install min_value rule and message
extend("min_value", min_value);

// Install min rule and message
extend("min", min);

// Install max rule and message
extend("max", max);

// Install max_value rule and message
extend("max_value", max_value);