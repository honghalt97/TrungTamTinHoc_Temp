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
            "aoColumnDefs": [{ "bSortable": false, "aTargets": [0, 3] }],
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
        $(document).on('change', '.link', function () {
            updateLink(this);
        });
        $(document).on('change', '.caption-img', function () {
            updateCaption(this);
        });
        $(document).on('click', '.btn-del', function () {
            var btn = this;
            jMessage(10, function (r) {
                if (r) {
                    deleteAlbum(btn);
                }
            });
        });
        $('#btn-save').on('click', function () {
            SubmitAnh();
        });
        $('.link-img').on('change', function () {
            var input = this;
            $(input).parents('.have-img').find('.review').first().attr('src', $(input).val());
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Event:</b> ' + e.message, 4);
    }
}
function SubmitAnh() {
    try {
        if (!validate('#form-album')) {
            $('#form-album').ajaxSubmit({
                beforeSubmit: function (a, f, o) {
                    o.dataType = 'json';
                },
                complete: function (XMLHttpRequest, textStatus) {
                    var res = XMLHttpRequest.responseJSON;
                    if (res.Code == 200) {
                        callLoading();
                        window.location = window.location;
                    } else {
                        jMessage(res.MsgNo, function (ok) { });
                    }
                },
            });
        }
        else {
            $('.item-error').first().focus();
        }
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>SubmitKhoaHoc:</b> ' + e.message, 4);
    }
}
function updateLink(input) {
    try {
        $.ajax({
            type: 'GET',
            url: '/admin/Alum/UpdateLink?id=' + $(input).attr('id-album') + "&&link=" + $(input).val(),
            success: function (res) {

            }
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>updateLink:</b> ' + e.message, 4);
    }
}
function updateCaption(input) {
    try {
        $.ajax({
            type: 'GET',
            url: '/admin/Alum/UpdateCaption?id=' + $(input).attr('id-album') + "&&note=" + $(input).val(),
            success: function (res) {

            }
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>updateCaption:</b> ' + e.message, 4);
    }
}
function deleteAlbum(input) {
    try {
        $.ajax({
            type: 'GET',
            url: '/admin/Alum/DeleteAlbum?id=' + $(input).attr('id-album'),
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