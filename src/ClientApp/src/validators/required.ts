import {extend} from 'vee-validate';

extend('required', {
    validate(value) {
        return {
            required: true,
            valid: ['', null, undefined].indexOf(value) === -1
        };
    },
    computesRequired: true,
    message: "Pole jest wymagane"
});