/*
 * Các xử lý cho trang login
 * Author       :   QuyPN - 27/05/2018 - create
 * Package      :   public/home
 * Copyright    :   Team Noname
 * Version      :   1.0.0
 */
$(document).ready(function () {
    InitLogin();
    InitEventLogin();
});
/*
 * Khởi tạo các giá trị ban đầu cho trang
 * Author       :   QuyPN - 27/05/2018 - create
 * Param        :   
 * Output       :   
 */
function InitLogin() {
    try {
        $('[tabindex="1"]').first().focus();
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Login:</b> ' + e.message, 4);
    }
}
/*
 * Khởi tạo các sự kiện của cho trang
 * Author       :   QuyPN - 27/05/2018 - create
 * Param        :   
 * Output       :   
 */
function InitEventLogin() {
    try {
        $('#btn-login').on('click', function () {
            SubmitLogin();
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Event Login:</b> ' + e.message, 4);
    }
}
/*
 * Thực hiện kiểm tra thông tin login
 * Author       :   QuyPN - 27/05/2018 - create
 * Param        :   
 * Output       :   
 */
function SubmitLogin() {
    try {
        if (!validate('#form-login')) {
            $.ajax({
                type: 'POST',
                url: $('#form-login').attr('action'),
                dataType: 'json',
                data: {
                    Username: $('#Username').val(),
                    Password: calcMD5($('#Password').val())
                },
                success: CheckLoginSuccess
            });
        }
        else {
            $('.item-error').first().focus();
        }
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Submit Login:</b> ' + e.message, 4);
    }
}
/*
 * Xử lý dữ liệu trả về sau khi request lên server để kiểm tra tài khoản login
 * Author       :   QuyPN - 28/05/2018 - create
 * Param        :   res - Đối tượng trả về từ server
 * Output       :   
 */
function CheckLoginSuccess(res) {
    try {
        if (res.Code == 200) {
            callLoading();
            window.location = "/admin/dashboard";
        } else if (res.Code == 201) {
            fillError(res.ListError);
            $('.item-error').first().focus();
        } else if (res.Code == 203 || res.Code == 205) {
            jMessage(0, function (ok) {
            }, createMessage(res.MsgNo, res.ThongTinBoSung1, res.ThongTinBoSung2, res.ThongTinBoSung3), 4);
        } else {
            jMessage(res.MsgNo, function (ok) { });
        }
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Check Login Success:</b> ' + e.message, 4);
    }
}
