

    var counter = 1;
    const centersData = [
    {Id: 1, Name: "AI" },
    ];
    // Populate the dropdown
    const dropdown = $(".MyDropDown");
        centersData.forEach(center => {
        dropdown.append($("<option />").val(center.Id).text(center.Name));
        });
    // Optional: Handle dropdown events (e.g., change event)
    dropdown.on("change", function () {
            const selectedCenterId = $(this).val();
    console.log("Selected Center ID:", selectedCenterId);
            // You can perform additional actions based on the selected value.
        });
    function AddNewForm() {
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
    $('select').last();
    $(".MyForm")
    .eq(0)
    .clone()
    .find("input").val("").end()
    .show()
    .insertAfter(".MyForm:last")
    counter++;
            }
    console.log('counter is : ' + counter)
    $('select').select2();

        }
    function CancelForm(buttonClicked) {
            if (counter > 1) {
        $(buttonClicked).closest('.MyForm').remove();
    counter--;
    console.log('cancelForm1 if method counter is :' + counter)
            } else {

        alert("Cannot remove this form. !!!");
            }
        }
    function extractFormData() {
               
                const form = $('.MyForm');
    console.log(form);

    var formData = new FormData(form[0]);
    console.info(...formData);
    $.ajax({
    url: '/Admin/AddCourse',
    type: 'POST',
    data: formData,
    success: function (data) {
        alert(data)
        console.log("aaaaaaaaaa")
       },
    beforeSend: function (one, two, three) {
        console.log(one);
    console.log(two);
                        
                    },
    cache: false,
    contentType: false,
    processData: false
                });
                
            
        }