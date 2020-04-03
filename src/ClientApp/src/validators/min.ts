import {extend} from 'vee-validate';

extend('min', {
    validate(value, args) {
        return value.length >= args.length;
    },
    params: ['length'],
    message: "Pole musi mieć minimalną długość {length}"
});