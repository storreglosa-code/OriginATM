// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let numero = "";
let PIN = "";

function agregarDigito(digito, inputId) {
    let input = document.getElementById(inputId);
    if (inputId == "numeroTarjeta") {
        console.log("NUMERO DE TARJETA")
        if (input=="" || numero.length < 16) {
            numero += digito;
            formatearNumeroTarjeta(inputId);
        }
    }
    if (inputId == "numeroPIN") {
        console.log("NUMERO pin")
        if (input == "" || input.value.length < 3) {
            input.value += digito;
            console.log("input.value:",input.value)
        }
    }
}
function limpiar(inputId) {
    let input = document.getElementById(inputId);
    numero = "";
    if (input) {
        input.value = '';
    }
}
function formatearNumeroTarjeta(inputId) {
    let separado = numero.match(/.{1,4}/g)?.join("-") || "";
    document.getElementById(inputId).value = separado;
}

function agregarDigitoPIN(digito) {
    if (numero.length >= 4) return;

    PIN += digito;
}

function enviarNumeroTarjeta() {
    document.getElementById("numeroPlano").value = numero;
    document.getElementById("formTarjeta").submit();
}
