var process_select_product_search_ajax = function () {
    $('.ele-search').click(function () {
        var ele = "";
        var name = $(this).data('name');
        var id = $(this).data('id');
        var price = $(this).data('price');
        var discount = $(this).data('discount');
        // var length_ = parseInt($('.ele-content').length);
        var index_ = parseInt($('#index-ele').val());
        //console.log("Lượng phần tử :" + $("[data-idp_='" + id + "']").length); 
        var flag_update_order = $('#search-product').data('flagproduct');
        var str_tl_ck = "";
        if (flag_update_order == "1") {
            //str_tl_ck = "";
            if ($('.head-table-customize').length == 0) {
                ele += '<div class="row head-table-customize" style="margin-top:10px;margin-bottom:8px">';
                ele += '<div class="col-sm-3 col-xs-3"><b>Name</b></div>'
                    + '<div class="col-sm-2 col-xs-2"><b>Price</b></div>'
                     + '<div class="col-sm-2 col-xs-2"><b>Discount</b></div>'
                    + '<div class="col-sm-2 col-xs-2"><b>Quantity</b></div>'
                    + '<div class="col-sm-2 col-xs-2"><b>Total</b></div>'
                    + '<div class="col-sm-1 col-xs-1"></div>'
                    + '</div>';
                $('#show-total').show();
            }
            if (parseInt($("[data-idp_='" + id + "']").length) > 0) {
                var q = parseInt($('.cell-' + id).val());
                $('.cell-' + id).val(q + 1);
                var pr_ = parseFloat($('#pr_' + id).val());
                $('#tt_' + id).html(numeral(pr_ * (q + 1)).format('0,0') + " ₫");
                process_sum_total();
                // console.log(numeral(pr_ * (q + 1)).format('0,0'));
                return;
            }

            ele += '<div class="row ele-content" id="p-' + (index_ + 1) + '" data-idp_="' + id + '" style="margin-top:3px;margin-bottom:2px">';
            ele += '<input type="hidden" name="Product[]" value="' + id + '">';
            ele += '<div class="col-sm-3 col-xs-3">' + name + '</div>'
                + '<div class="col-sm-2 col-xs-2">'
                + '<input type="hidden" id="pr_' + id + '" name="Product[' + id + '][price]" value="' + price + '" />'
                + numeral(price).format('0,0') + " ₫" + '</div>'
                + '<div class="col-sm-2 col-xs-2"><input type="number" name="Product[' + id + '][discount]" id="d-p-' + id + '" data-idp="' + id + '" class="form-control input-customize discount-product" min="0" value="' + parseFloat(discount)*100 + '" /></div>'
                + '<div class="col-sm-2 col-xs-2"><input type="number" name="Product[' + id + '][quantity]" id="q-p-' + id + '" data-idp="' + id + '" class="form-control input-customize quantity-product cell-' + id + '" value="1" min="1"/></div>'
                + '<div class="col-sm-2 col-xs-2"><span id="tt_' + id + '" class="total-cus">' + numeral(price).format('0,0')+ " ₫" + '</span></div>'
                + '<div class="col-sm-1 col-xs-1"><a href="javascript:void(0);" class="btn-delete-ele-product" data-item="' + (index_ + 1) + '"><i class="fa fa-trash-o"></i></a></div>'
                + '</div>';


        }
        else {
            if ($('.head-table-customize').length == 0) {
                ele += '<div class="row head-table-customize" style="margin-top:10px;margin-bottom:8px">';
                ele += '<div class="col-sm-3 col-xs-3"><b>Name</b></div>'
                    + '<div class="col-sm-3 col-xs-3"><b>Price</b></div>'
                    + '<div class="col-sm-2 col-xs-2"><b>Quantity</b></div>'
                    + '<div class="col-sm-3 col-xs-3"><b>Total</b></div>'
                    + '<div class="col-sm-1 col-xs-1"></div>'
                    + '</div>';
                $('#show-total').show();
            }
            if (parseInt($("[data-idp_='" + id + "']").length) > 0) {
                var q = parseInt($('.cell-' + id).val());
                $('.cell-' + id).val(q + 1);
                var pr_ = parseFloat($('#pr_' + id).val());
                $('#tt_' + id).html(numeral(pr_ * (q + 1)).format('0,0'));
                process_sum_total();
                return;
            }
            ele += '<div class="row ele-content" id="p-' + (index_ + 1) + '" data-idp_="' + id + '" style="margin-top:3px;margin-bottom:2px">';
            ele += '<input type="hidden" name="Product[]" value="' + id + '">';
            ele += '<div class="col-sm-3 col-xs-3">' + name + '</div>'
                + '<div class="col-sm-3 col-xs-3">'
                + '<input type="hidden" id="pr_' + id + '" name="Product[' + id + '][price]" value="' + price + '" />'
                + numeral(price).format('0,0') + " ₫" + '</div>'
                + '<div class="col-sm-2 col-xs-2"><input type="number" name="Product[' + id + '][quantity]" id="q-p-' + (index_ + 1) + '" data-idp="' + id + '" class="form-control input-customize quantity-product cell-' + id + '" value="1" min="1"/></div>'
                + '<div class="col-sm-3 col-xs-3"><span id="tt_' + id + '" class="total-cus">' + numeral(price).format('0,0') + " ₫" + '</span></div>'
                + '<div class="col-sm-1 col-xs-1"><a href="javascript:void(0);" class="btn-delete-ele-product" data-item="' + (index_ + 1) + '"><i class="fa fa-trash-o"></i></a></div>'
                + '</div>';
        }
       
        var content_p = $('#content-product-search').html();
        $('#content-product-search').append(ele);
        $('#index-ele').val(index_ + 1);
        process_sum_total();
        process_delete_click_ele_product();
        process_change_quantity();
        process_change_discount();
       // console.log($('.ele-content').length);
    });

};



$(function () {
    process_search_ajax();
    process_delete_click_ele_product();
    process_change_quantity();
    process_change_discount();
});
var process_search_ajax = function () {
    $('#search-product').on('keyup', function () {
        //console.log('abc');
        var width_ = $(this).outerWidth();
        if ($.trim($(this).val()) != '') {
            var url = $(this).data('urlsearch');
            var key_ = $(this).val();
            $.ajax({
                url: url + "?query=" + $(this).val(),
                type: 'GET',
                success: function (data) {
                    if (data != null) {
                        // var data_ = JSON.parse(data);
                        var str = "";
                        console.log(data);
                        for (var i = 0; i < data.length; i++) {
                            var re = '' + key_ + '';
                            var a = new RegExp(re,"gi");
                            var name = data[i].name + "";
                            str += "<li><a href='javascript:void(0);' class=\"ele-search\" data-name='"+name+"' data-id='" + data[i].id + "' data-price='" + data[i].price + "' data-discount='"+data[i].discount+"'>" + name.replace(a, "<strong style=\"color:black\">" + key_ + "</strong>") + "</a></li>";
                        }

                    }
                    //console.log(width_);
                    $('#menu-typesearch').css('width',width_);
                    $('#menu-typesearch').css('display', 'block');
                    $('#menu-typesearch').html(str);
                    process_select_product_search_ajax();
                },
                error: function (resoponse) {
                }
            });
        } else {
            $('#menu-typesearch').css('display', 'none');
        }
      

    });
};
var process_delete_click_ele_product = function () {
    $('.btn-delete-ele-product').click(function () {
        if (confirm("Are you want delete item ?")) {
            var index = $(this).data('item');
            //$(this).parent().parent().remove();
            $('#p-' + index).remove();
            process_sum_total();
        }
    });
};
var process_sum_total = function () {
    var total = 0;
    $.each($('.total-cus'), function () {
        var pr__ = $(this).html() + "";
        var amount = parseFloat(pr__.replace(/\,/gi, ""));
        total += amount;
    });
    $('#sum-total').html(numeral(total).format('0,0') + " ₫");
    $('#total-sum-input').val(total);

};
var process_change_quantity = function () {
    $('.quantity-product').click(function () {
       //alert('abc');
        if ($.trim($(this).val()) != '') {
            var id = $(this).data('idp');
            var q = parseInt($(this).val());
            var discount = 0;
            if ($('.discount-product').length > 0) {
                discount = $("#d-p-" + id).val();
            }
            var price = parseFloat($('#pr_' + id).val());
            console.log(q + "-" + price+ "-"+discount);
            $('#tt_' + id).html(numeral((q * price) - (price * q * discount / 100)).format('0,0')+ " ₫");
            process_sum_total();
        }
        
    });
    $('.quantity-product').blur(function () {
        //alert('abc');
        if ($.trim($(this).val()) != '') {
            var id = $(this).data('idp');
            var q = parseInt($(this).val());
            var discount = 0;
            if ($('.discount-product').length > 0) {
                discount = $("#d-p-" + id).val();
            }
            var price = parseFloat($('#pr_' + id).val());
            console.log(q + "-" + price + "-" + discount);
            $('#tt_' + id).html(numeral((q * price) - (price * q * discount / 100)).format('0,0') + " ₫");
            process_sum_total();
        }
    });

}
var process_change_discount = function () {
    $('.discount-product').click(function () {
        //alert('abc');
        if ($.trim($(this).val()) != '') {
            var id = $(this).data('idp');
            var dis = parseFloat($(this).val());
            var q = parseInt($('#q-p-' + id).val());
            //if($()){}
            var price = parseFloat($('#pr_' + id).val());
            console.log(q + "-" + price + " - " + dis);
            $('#tt_' + id).html(numeral((q * price) - (price * q * dis / 100)).format('0,0') + " ₫");
            process_sum_total();
        }

    });
    $('.discount-product').blur(function () {
        //alert('abc');
        if ($.trim($(this).val()) != '') {
            var id = $(this).data('idp');
            var dis = parseFloat($(this).val());
            var q = parseInt($('#q-p-' + id).val());
            //if($()){}
            var price = parseFloat($('#pr_' + id).val());
            console.log(q + "-" + price + " - " + dis);
            $('#tt_' + id).html(numeral((q * price) - (price * q * dis / 100)).format('0,0') + " ₫");
            process_sum_total();
        }
    });

}