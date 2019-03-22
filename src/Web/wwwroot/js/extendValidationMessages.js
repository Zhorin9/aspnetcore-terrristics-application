jQuery.extend(jQuery.validator.messages, {
    required: "Pole jest wymagane.",
    remote: "Proszę popraw pole.",
    email: "Wprowadź poprawny email.",
    url: "Wprowadź poprawny adres url.",
    date: "Wprowadź poprawną date.",
    number: "Wprowadź c.",
    digits: "Wprowadź tylko cyfry.",
    equalTo: "Wprowadź taka sama nazwe.",
    accept: "Please enter a value with a valid extension.",
    maxlength: jQuery.validator.format("Tekst nie powinien być dłuższy niż {0} znaków."),
    minlength: jQuery.validator.format("Tekst nie powinien być krótszy niż {0} znaków."),
    rangelength: jQuery.validator.format("Tekst powinien mieć między {0} a {1} znaków."),
    range: jQuery.validator.format("Wprowadź wartość między {0} i {1}."),
    max: jQuery.validator.format("Wartość powinna być mniejsza równa niż {0}."),
    min: jQuery.validator.format("Wartość powinna być większa równa niż {0}.")
});
