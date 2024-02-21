
$(document).ready(function () {
    //$("#cart-item").click(function () {
    var urlload = $('#url_loadcart').data('urlloadcart');
    console.log('giá trị urlload' + urlload);
        $("#cart-item").load(urlload);
    //});
           

});
