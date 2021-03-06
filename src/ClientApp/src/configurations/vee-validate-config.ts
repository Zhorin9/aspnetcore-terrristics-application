// Setup vee-validate globally https://logaretm.github.io/vee-validate/guide/basics.html#registering-the-validation-provider

import Vue from 'vue';
import {ValidationProvider, ValidationObserver, extend} from "vee-validate";
import {required, email, min, min_value, max, max_value} from 'vee-validate/dist/rules'

Vue.component('validation-provider', ValidationProvider);
Vue.component('validation-observer', ValidationObserver);

import {localize} from 'vee-validate';

const en = require('vee-validate/dist/locale/en.json');
en.names = {
    email: 'E-mail',
    password: 'Password',
    name: 'Name',
    description: 'Description',
    sensorType: 'Type',
};
localize('en', en);

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
