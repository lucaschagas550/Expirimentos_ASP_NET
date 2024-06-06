$(document).ready(function () {
    $('#date').mask('00/00/0000')
    $('#number').mask('000')
    $('.money').mask('000.000.000.000.000,00', { reverse: true });
    $('#time').mask('00:00');
});