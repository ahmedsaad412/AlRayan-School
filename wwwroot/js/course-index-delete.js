
$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this)

        const swal = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-danger",
                cancelButton: "btn btn-light"
            },
            buttonsStyling: false
        });
      
        swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
            
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax
                    ({
                        url:`/Course/SoftDelete/${btn.data('Id')}`,
                        method: 'DELETE',
                        success: function () {
                            swal.fire({
                                title: "Deleted!",
                                text: "Course has been deleted.",
                                icon: "success"
                            });
                            btn.parents('tr').fadeOut();
                            $('#alert').removeClass('d-none');
                            setTimeout(function () { $('#alert').addClass('d-none'); }, 3000)
                        },
                        error: function () {
                            swal.fire({
                                title: "Deleted!",
                                text: "Something went wrong",
                                icon: "error"
                            });
                        }
                                           
                });
            } 
        });
    });
});

    