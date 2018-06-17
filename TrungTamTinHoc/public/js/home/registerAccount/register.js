/*
 * Các xử lý cho trang đăng ký tài khoản
 * Author       :   QuyPN - 16/06/2018 - create
 * Package      :   public/home
 * Copyright    :   Team Noname
 * Version      :   1.0.0
 */
$(document).ready(function () {
    InitRegister();
    InitEventRegister();
});
/*
 * Khởi tạo các giá trị ban đầu cho trang
 * Author       :   QuyPN - 27/05/2018 - create
 * Param        :   
 * Output       :   
 */
function InitRegister() {
    try {
        $('[tabindex="1"]').first().focus();
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Register:</b> ' + e.message, 4);
    }
}
/*
 * Khởi tạo các sự kiện của cho trang
 * Author       :   QuyPN - 27/05/2018 - create
 * Param        :   
 * Output       :   
 */
function InitEventRegister() {
    try {
        $('#btn-regist').on('click', function () {
            DangKyTaiKhoan();
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Event Register:</b> ' + e.message, 4);
    }
}
/*
 * Tiến hành gửi thông tin lên server để đăng ký tài khoản
 * Author       :   QuyPN - 16/06/2018 - create
 * Param        :   
 * Output       :   
 */
function DangKyTaiKhoan() {
    try {
        var error1 = validate('#form-register');
        var error2 = validateValue();
        if (!error1 && !error2) {
            $.ajax({
                type: $('#form-register').attr('method'),
                url: $('#form-register').attr('action'),
                dataType: 'json',
                data: {
                    Username: $('#Username').val(),
                    Ho: $('#Ho').val(),
                    Ten: $('#Ten').val(),
                    GioiTinh: $('#GioiTinh').val(),
                    NgaySinh: ddmmyyyyToDate($('#GioiTinh').val()),
                    Email: $('#Email').val(),
                    Password: calcMD5($('#Password').val()),
                    ConfirmPassword: $('#ConfirmPassword').val(),
                    Agree: $('#Agree').is(":checked") ? true : false
                },
                success: CreateAccountRespon
            });
        }
        else {
            $('.item-error').first().focus();
        }
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>DangKyTaiKhoan:</b> ' + e.message, 4);
    }
}

/*
 * Kiểm tra các điều kiện ràng buộc khắc về dữ liệu của trang đăng ký
 * Author       :   QuyPN - 16/06/2018 - create
 * Param        :   
 * Output       :   true nếu có lỗi - false nếu không có lỗi
 */
function validateValue() {
    try {
        var error = false;
        var lang = getLang();
        var regUsername = /^[a-zA-Z0-9_.-]{6,50}$/;
        var resPassword = /^(?=.*\d)(?=.*[a-zA-Z])[a-zA-Z0-9]{8,50}$/;
        if ($('#Username').val() != '' && !regUsername.test($('#Username').val())) {
            error = true;
            $('#Username').errorStyle(_text[lang][MsgNo.TenDangNhapSai]);
        }
        if ($('#Password').val() != '' && !resPassword.test($('#Password').val())) {
            error = true;
            $('#Password').errorStyle(_text[lang][MsgNo.SaiFormatMatKhau]);
        }
        if ($('#ConfirmPassword').val() != '' && $('#Password').val() != $('#ConfirmPassword').val()) {
            error = true;
            $('#ConfirmPassword').errorStyle(_text[lang][MsgNo.XacNhanMatKhauSai]);
        }
        if (!$('#Agree').is(":checked")) {
            error = true;
            $('#Agree').parents(".custom-check").find(".checkmark").first().errorStyle(_text[lang][MsgNo.ChuaDongYVoiDieuKhoan]);
        }
        return error;
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Validate Value:</b> ' + e.message, 4);
        return true;
    }
}

/*
 * Xử lý sau khi đăng ký tài khoản
 * Author       :   QuyPN - 17/06/2018 - create
 * Param        :   res - đối tượng response trả về từ server
 * Output       :  
 */
function CreateAccountResponse(res) {
    try{

    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Create Account Response:</b> ' + e.message, 4);
        return true;
    }
}