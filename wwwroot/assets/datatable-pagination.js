$(function () {
    var id = $("table[id^=tbl_]");
    $(id).dataTable({
        "columnDefs": [
            { "sortable": false, "targets": [2, 3] }
        ]
    });


});
