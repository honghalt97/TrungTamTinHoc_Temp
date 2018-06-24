/*
 * Các xử lý cho trang login
 * Author       :   QuyPN - 27/05/2018 - create
 * Package      :   public/home
 * Copyright    :   Team Noname
 * Version      :   1.0.0
 */
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
        $('[tabindex="1"]').first().focus();
        CKEDITOR.replace('ChiTiet', {
            height: 500
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
        $('#TenKhoaHoc').on('keyup', function () {
            if ($('#mode').val() == "I") {
                SetBeauTyId();
            }
        });
        $('#btn-save').on('click', function () {
            SubmitKhoaHoc();
        });
        $('#AnhMinhHoa').on('blur', function () {
            $('#view-img').attr('src', $(this).val());
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Event:</b> ' + e.message, 4);
    }
}
function SubmitKhoaHoc() {
    try {
        if (!validate('#form-khoa-hoc')) {
            $('#ChiTiet').val(CKEDITOR.instances.ChiTiet.getData());
            $('#form-khoa-hoc').ajaxSubmit({
                beforeSubmit: function (a, f, o) {
                    o.dataType = 'json';
                },
                complete: function (XMLHttpRequest, textStatus) {
                    var res = XMLHttpRequest.responseJSON;
                    if (res.Code == 200) {
                        callLoading();
                        window.location = "/admin/QuanLyKhoaHoc/KhoaHoc?id=" + res.ThongTinBoSung1;
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
function SetBeauTyId() {
    try{
        if ($('#TenKhoaHoc').val() == '') {
            $('#BeautyId').val('');
        }
        var str = $('#TenKhoaHoc').val().toLowerCase().trim().replace(/ /g, "-");
        str = getStringWithoutDiacritics(str);
        $('#BeautyId').val(str);
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>SetBeauTyId:</b> ' + e.message, 4);
    }
}
function getStringWithoutDiacritics(str) {
    var strTemp = str;

    strTemp = strTemp.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    strTemp = strTemp.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    strTemp = strTemp.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    strTemp = strTemp.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    strTemp = strTemp.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    strTemp = strTemp.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    strTemp = strTemp.replace(/đ/g, "d");
    strTemp = strTemp.replace(/[^a-zA-Z0-9---]/g, "")
    strTemp = strTemp.replace(/----/g, "-");
    strTemp = strTemp.replace(/---/g, "-");
    strTemp = strTemp.replace(/--/g, "-");

    return strTemp;
}