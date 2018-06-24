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
            "aoColumnDefs": [{ "bSortable": false, "aTargets": [8, 10] }],
            "order": [[9, "asc"]]
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
        $(document).on('change', '.ghi-chu', function () {
            updateGhiChu(this);
        });
        $(document).on('change', '.trang-thai', function () {
            updateTrangThai(this);
        });
        $(document).on('click', '.btn-del', function () {
            var btn = this;
            jMessage(10, function (r) {
                if (r) {
                    deleteDangKy(btn);
                }
            });
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Event:</b> ' + e.message, 4);
    }
}

function updateGhiChu(input) {
    try {
        $.ajax({
            type: 'GET',
            url: '/admin/DangKyKhoaHoc/UpdateGhiChu?id=' + $(input).attr('id-dang-ky') + "&&ghiChu=" + $(input).val(),
            success: function (res) {

            }
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>updateGhiChu:</b> ' + e.message, 4);
    }
}
function updateTrangThai(input) {
    try {
        $.ajax({
            type: 'GET',
            url: '/admin/DangKyKhoaHoc/UpdateTrangThai?id=' + $(input).attr('id-dang-ky') + "&&trangThai=" + $(input).val(),
            success: function (res) {

            }
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>updateTrangThai:</b> ' + e.message, 4);
    }
}
function deleteDangKy(input) {
    try {
        $.ajax({
            type: 'GET',
            url: '/admin/DangKyKhoaHoc/DeleteDangKy?id=' + $(input).attr('id-dang-ky'),
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
        }, '<b>deleteDangKy:</b> ' + e.message, 4);
    }
}