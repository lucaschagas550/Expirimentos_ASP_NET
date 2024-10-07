$(document).ready(function () {
    $('#date').mask('00/00/0000')
    $('#number').mask('000')
    $('.money').mask('000.000.000.000.000,00', { reverse: true });
    $('#time').mask('00:00');
    //permite numeros infinitos antes da virgula e apenas duas casas decimais
    $('.porcentagem-ilimitado-decimal-duas-casas').mask('#.##0,00', { reverse: true });
});