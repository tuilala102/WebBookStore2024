//$(document).delegate(".removeProduct", "click", function () {

//    pid = $(this).attr("data-id-remove");

//    $.ajax({
//        url: "/Cart/Remove",
//        data: { id: pid },
//        success: function (response) {
//            $("#nn-cart-count").html(response.Count);
//            $(".nn-cart-total").html(response.Total);
//            $("#" + pid + " sp").hide(500);
//            $("#cart-item").load("/Cart/PartialCart");
//        }
//    });

//});

$(function () {
    // Xóa khỏi giỏ
    //$(".remove-from-cart").click(function ()

    $(document).delegate(".remove-from-cart, .removeProduct", "click", function () {
        pid = $(this).attr("data-id");
        tr = $(this).parents("tr");// tim <tr> chua <img> bi click
        var url_remove = $(this).data('urlremovecart');
       // console.log(url_remove); return;
        $.ajax({
            url: url_remove,
            data: { id: pid },
            success: function (response) {
               // alert("abcasdsa"); return;
                $("#nn-cart-count").html(response.count);
                var s = response.total + "";
                var x = s.replace(/\./g, '');
                $(".nn-cart-total").html(numeral(parseFloat(x)).format('0,0'));
                $("#cart-item").load($('#url_loadcart').data('urlloadcart'));
                tr.hide(500);
            }
        });
    });
    // Cập nhật số lượng

    $(document).delegate(".quantity, .spquantity", "keyup", function () {
        pid = $(this).attr("data-id");
        qty = $(this).val();
        var url_updatecart = $(this).data("urlupdatecart");
        //$("#"+pid+"-ss").val(qty);
        $.ajax({
            url: url_updatecart,
            data: { id: pid, quantity: qty },
            success: function (response) {
                $("#nn-cart-count").html(response.count);
                $(".nn-cart-total").html(response.total);
                $("#" + pid).html(" " + response.amount);
                $("#" + pid + "-ss").attr("value", response.quantity);

                //$("#" + pid).html("$" + response.quantity);

                $("#cart-item").load($('#url_loadcart').data('urlloadcart'));

            }
        });
    });

});