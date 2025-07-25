// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let numero = "";
let PIN = "";
const longitudTarjeta = 16;
const longitudPin = 3;
function agregarDigito(digito, inputId) {
    let input = document.getElementById(inputId);
    if (inputId == "numeroFormateado") {
        if (input == "" || numero.length < longitudTarjeta) {
            numero += digito;
            document.getElementById("numeroTarjeta").value = numero;
            formatearNumeroTarjeta(inputId);
        }
    }
    if (inputId == "inputPIN") {
        if (input == "" || input.value.length < longitudPin) {
            input.value += digito;
        }
    }
    if (inputId == "inputMontoRetiro") {
            input.value += digito;
    }
}
function limpiar(inputId) {
    let input = document.getElementById(inputId);
    numero = "";
    if (input) {
        input.value = "";
    }
}
function formatearNumeroTarjeta(inputId) {
    let separado = numero.match(/.{1,4}/g)?.join("-") || "";
    document.getElementById(inputId).value = separado;
}
