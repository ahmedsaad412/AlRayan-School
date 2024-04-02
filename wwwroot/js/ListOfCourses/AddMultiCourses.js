$(document).ready(function () {

    debugger;

    var counter = 1;
    $("#addNewForm").click(function () {
        if (counter > 10) {
            alert("Only 10 textboxes allowed");
            return false;
        }
        else {
            $('select').select2('destroy');
            $('select')
                .removeAttr('data-live-search')
                .removeAttr('data-select2-id')
                .removeAttr('aria-hidden')
                .removeAttr('tabindex');
            var cc = $('select').last();
            console.log(cc);

            $(".MyForm")
                .eq(0)
                .clone()
                .find("input").val("").end()
                .show()
                .insertAfter(".MyForm:last")
            counter++;
        }
        $('select').select2();
    });
    $('.container').on('click', ".cancel", function () {

        if (counter > 1) {
            $(this).closest('.MyForm').remove();
            counter--;
        } else {

            alert("Cannot remove the first form.");
        }

    });
});  