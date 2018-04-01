var state;
var httpServiceInstance;
/**
 * A wrapper for $.ajax operations
**/
var HttpService = (function (state) {
    'use strict';
    function HttpService(state) {
        this.state = state;
        this.post = post;
        this.get = get;
        this.callAction = callAction;
    }
    // post action 
    function post(url, request, config, callback) {
        var _this = this;
        _this.callAction(url, "POST", request, config, callback);
    };
    // get action 
    function get(url, request, config, callback) {
        var _this = this;
        _this.callAction(url, "GET", request, config, callback);
    };
    // call action which invokes ajax 
    function callAction(url, method, request, config, callback) {
        var currentPath = window.location.pathname;
        var currentPage = currentPath.substr(currentPath.lastIndexOf('/') + 1);
        url = currentPage + "/" + url;

        $.ajax({
            type: method,
            url: url,
            data: JSON.stringify(request),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function () {
                if (config && config.showLoading) {
                    ShowLoadingPanel();
                }
            },
            error: function (e) {
                alert(e);
            },
            success: function (response) {
                if (config && config.showLoading) {
                    HideLoadingPanel();
                }
                return callback(response);
            }
        });
    }
    // return instance of singleton object
    if (!httpServiceInstance)
        httpServiceInstance = new HttpService();
    return httpServiceInstance;
})(state || (state = {}));
