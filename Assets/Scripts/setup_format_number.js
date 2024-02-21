$(function () {
    //alert("abc");
    setFormatDecimal("₫");
});
var setFormatDecimal = function (curency) {
    //var number = parseInt($('.numeral-init').html());
   // console.log($('.numeral-init').html());
    $.each($('.numeral-init'), function (index,item) {
        console.log($(this).html());
        var number = parseFloat($(this).html());
        $(this).html(numeral(number).format('0,0') + " " + curency);
    });
    //$('.numeral-init').html(numeral(number).format('0,0') + " "+curency);
};