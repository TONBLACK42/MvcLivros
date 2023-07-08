//Substitui o ponto pela virgula ao validar inputs decimais. Muito adequado para inputs de valor monetário.
$.validator.methods.range = function (value, element, param) {
    var globalizedValue = value.replace(",", ".");
    return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
};

$.validator.methods.number = function (value, element) {
    return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
};

//DesabilitarBotaoDeSubmitAposClique();

function DesabilitarBotaoDeSubmitAposClique() {

    var $forms = document.querySelectorAll('form');

    $forms.forEach(form => {

        form.addEventListener('submit', (e) => {

            var formValido = e.target.checkValidity();

            if (formValido) {
                var $botoes = e.target.querySelectorAll('[type=submit]');

                $botoes.forEach(b => {
                    b.setAttribute('disabled', true);
                });

            }

        });

    });
}