

var counter = 1;
const centersData = [
    { Id: 1, Name: "AI" },
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
    debugger;
    
    // Loop through each cloned form
    for (let i = 0; i < counter; i++) {
        const formSelector = `.MyForm:eq(${i})`;
        const form = $(formSelector);
        // Extract data from form fields
        const courseName = form.find(".name").val();
        const courseDescription = form.find(".description").val();
        const courseHours = form.find(".hours").val();
        const photo = form.find(".photo");
        const centerId = form.find(".MyDropDown").val();
        var formData = new FormData(this[0]);
        formData.append("Name", courseName)
        formData.append("Description", courseDescription)
        formData.append("Hours", courseHours)
        formData.append("Photo", photo[0].files[0])
        formData.append("CenterId", centerId)
        // Add the object to the list
        //formList.push(formData);
        //console.log('Name:', formData.get('Name'));
        //console.log('Description:', formData.get('Description'));
        console.info(...formData);
        //for (const pair of formData.entries()) {
        //    console.log(pair[0], pair[1]);
        //}
        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'multipart/form-data'
            },
            url: '/Admin/AddCourse',
            type: 'POST',
            data: formData,
            processData: true,
            beforeSend: function (one, two, three) {
                console.log(one);
                console.log(two);
               console.log(three);
                // setting a timeout
                
            },
            success: function (response) {
                // Handle the server response
                window.location.href = "/Course/Index";
                console.log('Data sent successfully:', response);
            },
            error: function (x, y, z) {
                console.log(x);
                console.log(y);
                console.log(z);
            },
        });
    }


}   