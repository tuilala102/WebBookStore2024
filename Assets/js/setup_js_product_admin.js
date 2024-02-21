$(document).ready(function () {

    init_check_valid_file_img("[name=uplImage]", "#Image");
});
var readimage = function (input,textboxname) {
    function readImage(input) {
        var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
        if (!regex.test($(input).val().toLowerCase())) {
            alert("Please upload file valid");
            $(input).val("");
        }
        else {
            var FR = new FileReader();
            FR.onload = function (e) {
              //  $('#img').attr("src", e.target.result);
                $(textboxname).val(e.target.result);
            };
            FR.readAsDataURL(input.files[0]);
        }
       

    }
};
var init_check_valid_file_img = function (name,textboxname) {
    $(name).on("change", function () {
        readimage(this, textboxname);
    });
};