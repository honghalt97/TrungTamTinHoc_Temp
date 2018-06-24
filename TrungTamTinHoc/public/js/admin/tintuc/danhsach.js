/*
 * Các xử lý cho trang login
 * Author       :   QuyPN - 27/05/2018 - create
 * Package      :   public/home
 * Copyright    :   Team Noname
 * Version      :   1.0.0
 */
var table;
$(document).ready(function () {
    Init();
    InitEvent();
});
/*
 * Khởi tạo các giá trị ban đầu cho trang
 * Author       :   QuyPN - 27/05/2018 - create
 * Param        :   
 * Output       :   
 */
function Init() {
    try {
        table = $('#datatable-responsive').DataTable({
            "aoColumnDefs": [{ "bSortable": false, "aTargets": [0, 3, 4] }],
            "order": [[1, "asc"]]
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init:</b> ' + e.message, 4);
    }
}
/*
 * Khởi tạo các sự kiện của cho trang
 * Author       :   QuyPN - 27/05/2018 - create
 * Param        :   
 * Output       :   
 */
function InitEvent() {
    try {
        $(document).on('change', '.show-tin-tuc', function () {
            updateShow(this);
        });
        $(document).on('click', '.btn-del', function () {
            var btn = this;
            jMessage(10, function (r) {
                if (r) {
                    deleteTinTuc(btn);
                }
            });
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Event:</b> ' + e.message, 4);
    }
}

function updateShow(input) {
    try {
        $.ajax({
            type: 'GET',
            url: '/admin/QuanLyTinTuc/UpdateShow?id=' + $(input).attr('id-tin-tuc') + "&&show=" + $(input).is(':checked'),
            success: function (res) {

            }
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>updateShow:</b> ' + e.message, 4);
    }
}
function deleteTinTuc(input) {
    try {
        $.ajax({
            type: 'GET',
            url: '/admin/QuanLyTinTuc/DeleteTinTuc?id=' + $(input).attr('id-tin-tuc'),
            success: function (res) {
                if (res.Code == 200) {
                    jMessage(12, function () {
                        table.rows($(input).parents('tr')).remove().draw();
                    });
                }
                else {
                    jMessage(res.MsgNo, function () {
                    });
                }
            }
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>deleteTinTuc:</b> ' + e.message, 4);
    }
}