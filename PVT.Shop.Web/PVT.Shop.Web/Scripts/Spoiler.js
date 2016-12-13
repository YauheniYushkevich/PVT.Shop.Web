$(document).ready(function () {
    $('.spoiler-explore').click(function () {
        $(this).parent().children('div.spoiler-content').toggle('fast');
        return false;
    });
});