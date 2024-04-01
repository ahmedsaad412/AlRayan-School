$(document).ready(function () {
    $('#Photo').on('change', function () {
        $('.photo-preview').attr('src', window.URL.createObjectURL(this.files[0])).removeClass('d-none')
    });
});