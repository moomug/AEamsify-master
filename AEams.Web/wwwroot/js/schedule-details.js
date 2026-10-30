function onAddScheduleSuccess(row) {
    showSuccessMessage();
    $('#Modal').modal('hide');

    $('tbody').prepend(row);
    KTMenu.createInstances();

    countPlusOrNot(+1)

    $('.js-alert').addClass('d-none');
    $('table').removeClass('d-none');
}

function countPlusOrNot(num) { 
    var count = $('#ScheduleCount');
    var newCount = parseInt(count.text()) + num;
    count.text(newCount);
}


function onEditScheduleSuccess(row) {
    showSuccessMessage();
    $('#Modal').modal('hide');

    $(updatedRow).replaceWith(row);
    KTMenu.createInstances();
}

