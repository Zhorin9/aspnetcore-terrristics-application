import {extend} from 'vee-validate';
import {email} from "vee-validate/dist/rules";

extend('email', {
    ...email,
    message: 'Wprowadź poprawny adres email'
});