$(document).ready(function () {
    $(document).on("submit", ".delete-job", function (event) {
        event.preventDefault();
        deleteJob($(this));
    });
});

function deleteJob($form) {
    if (confirm('Do you really want to delete this job?')) {
        var id = $form.find('#job_JobId').val();
        debugger
        $.ajax({
            url: $form.attr('action') + '/' + id,
            type: $form.attr('method'),
            success: function () {
                $('tr#job' + id).remove();
            }
        });
    }
}