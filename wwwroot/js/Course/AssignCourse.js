function AddCourse() {
    var name = $("#name").val();
    var description = $("#description").val();
    var hours = $("#hours").val();
    var centerId = 1;
    let fd = new FormData();
    fd.append("Name", name)
    fd.append("Description", description)
    fd.append("Hours", hours)
    fd.append("CenterId", centerId)
    console.log(fd);
    console.log(name);
    console.log(hours);

    $.ajax({
        url: "/Admin/AddCourse",
        type: "POST",
        contentType: 'application/json',
        processData: false,
        data: fd,
        success: function () {
            window.location.href = "/Course/Index";
            console.log("sss")

        },

    });
}