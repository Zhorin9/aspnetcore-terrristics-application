import {extend} from 'vee-validate';

extend('max', {
    validate(value, args) {
        return value.length <= args.length;
    },
    params: ['length'],
    message: "Pole może mieć maksymalną długość {length}"
});