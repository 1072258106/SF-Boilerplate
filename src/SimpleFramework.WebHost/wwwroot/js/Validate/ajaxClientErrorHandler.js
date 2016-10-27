(function ($) {
    'use strict';
    $(function () {
        $.ajaxSetup({

            timeout: 3000,

            dataType: 'html',

            //����ɹ��󴥷�

            success: function (data) { show.append('success invoke!' + data + '<br/>'); },

            //����ʧ�������쳣����

            error: function (xhr, status, e) {
                if (xhr.get_error() != undefined && xhr.get_error().httpStatusCode == '500') {
                    var errorName = xhr.geonse();
                    if (response) {

                        // if we got responseData (probably from Error.aspx.cs), use that as the error output
                        var responseData = response.get_responseData();
                        errorMessage = responseData;
                    }

                    $(".ajax-error-message").html(errorMessage);
                    $(".ajax-error").show();
                }
                else if (xhr.get_response() != undefined && xhr.get_response().get_timedOut() == true) {
                    $(".ajax-error-message").text("Request timed out.  Please try again later.");
                    $(".ajax-error").show();
                }
            },

            //�������󴥷�������success��error�����󴥷�

            complete: function (xhr, status) { show.append('complete invoke! status:' + status + '<br/>'); },

            //��������ǰ����

            beforeSend: function (xhr) {

                //���������Զ����ͷ
                $(".ajax-error").hide();

            },

        })
    });
}(jQuery));