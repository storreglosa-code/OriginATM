// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
    let numero = "";
function agregarDigito(digito) {
        if (numero.length >= 16) return;

    numero += digito;
    formatearNumeroTarjeta();
}

function formatearNumeroTarjeta() {
    let separado = numero.match(/.{1,4}/g)?.join("-") || "";
    document.getElementById("numeroTarjeta").value = separado;
}

function limpiarNumeroTarjeta() {
        numero = "";
        document.getElementById("numeroTarjeta").value = "";
}

function enviarNumeroTarjeta() {
    if (numero.length !== 16) {
        alert("Debe ingresar los 16 dígitos de la tarjeta.");
        return;
    }
    document.getElementById("numeroPlano").value = numero;
    document.getElementById("formTarjeta").submit();
}
