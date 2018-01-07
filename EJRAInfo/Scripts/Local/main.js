$(document).ready(function () {

    // see http://hilios.github.io/jQuery.countdown/ for documentation

    var cDate = new Date('2016/05/17 14:00:00');
    var cDateSignature = new Date('2016/04/25 12:00:00');
    var cDateVoting = new Date('2016/06/09 12:00:00');
    //cDate.setDate(cDate.getDate());

    $("#votingCountDown").countdown(cDateVoting, function (event) {
        $(this).text(
          event.strftime('%-D day%!D %H:%M:%S')
        )
    });

    $("#meetingCountDown").countdown(cDate, function (event) {
        $(this).text(
          event.strftime('%-D day%!D %H:%M:%S')
        )
    });
    
    $("#signatureCountDown").countdown(cDateSignature, function (event) {
        $(this).text(
          event.strftime('%-D day%!D %H:%M:%S')
        )
    });

});