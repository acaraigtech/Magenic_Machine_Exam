// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
    selectCardType();
});

function inputNumericOnly() {
    $('input[id="DiscountCardID"]').keyup(function (e) {
        if (/\D/g.test(this.value)) {
            // Filter non-digits and char "-" from input value.
            this.value = this.value.replace(/[^\d-]/g, '', '');
        }
    });
}

function inputIsSenior() {
    $("#btnBuyNow").attr('disabled', 'disabled');
    $("#DiscountCardID").attr("maxlength", 12);
    $('#DiscountCardID').keyup(function () {
        var txt = $(this);
        if (txt.val().length >= 2) {
            txt.val(txt.val().substr(0, 2) + '-' + txt.val().substr(3));
        }
        if (txt.val().length >= 7) {
            txt.val(txt.val().substr(0, 7) + '-' + txt.val().substr(8));
        }
        if (txt.val().length > 11) {
            $("#btnBuyNow").removeAttr('disabled');
        } else {
            $("#btnBuyNow").attr('disabled', 'disabled');
        }
    });
}

function inputIsPWD() {
    $("#btnBuyNow").attr('disabled', 'disabled');
    $("#DiscountCardID").attr("maxlength", 14);
    $('#DiscountCardID').keyup(function () {
        var txt = $(this);
        if (txt.val().length >= 4) {
            txt.val(txt.val().substr(0, 4) + '-' + txt.val().substr(5));
        }
        if (txt.val().length >= 9) {
            txt.val(txt.val().substr(0, 9) + '-' + txt.val().substr(10));
        }
        if (txt.val().length > 13) {
            $("#btnBuyNow").removeAttr('disabled');
        } else {
            $("#btnBuyNow").attr('disabled', 'disabled');
        }
    });
}

function selectCardType() {
    $('#Id').change(function () {
        //Use $option (with the "$") to see that the variable is a jQuery object
        var $option = $(this).find('option:selected');
        //Added with the EDIT
        var value = $option.val();//to get content of "value" attrib
        //var text = $option.text();//to get <option>Text</option> content
        if (value == "7df50cce-45de-4250-8c54-5f7d4f89cb76") {
            $("#discountCardIdFromGroup").attr('hidden', 'hidden');
        } else {
            $("#discountCardIdFromGroup").removeAttr('hidden');
            inputNumericOnly();
            inputIsPWD();
            $("#IsSenior").change(function () {
                inputNumericOnly();
                $('#DiscountCardID').val("");
                if (this.checked) {
                    $('#DiscountCardID').unbind("keyup")
                    inputIsSenior();
                } else {
                    $('#DiscountCardID').unbind("keyup")
                    inputIsPWD();
                }
            });
        }
    });
}



