
    $(document).ready(function (e) {
        //$(".search-field").keyup(function ()

   
        $(document).delegate(".search-field", "keyup", function () {
            search = $(".search-field").val();
            cat = $("#category").val();
            console.log(cat);
            urlsearch = $(this).data('urlsearch');

            //if (cat == 'undefined' || cat == "Categories" ||cat == null || cat=="") {
            //    cat =null;
            //}
        
            $.ajax({
                type:"post",
                url: urlsearch,
                data: { keywork: search, cat:cat },
                success: function (res) {
                    //$(".homebanner-holder").html("");
                    $(".homebanner-holder").html(res).replaceAll();
                }
            });
            return false;

        });



    });




