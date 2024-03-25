function AddCourse() {
    var name = $(".name").val();
    var description = $(".description").val();
    var hours = $(".hours").val();
    var centerId = $('select').find(':selected').val();
    let fd = new FormData();
    fd.append("Name", name)
    fd.append("Description", description)
    fd.append("Hours", hours)
    fd.append("CenterId", centerId)
    console.log(fd);
    console.log(name)
    console.log(hours)

    $.ajax({
        url: "/Admin/AddCourse",
        type: "POST",
        contentType: false,
        processData: false,
        data: fd,
        success: function () {
            window.location.href = "/Course/Index";
            console.log("sss")

        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    });
}