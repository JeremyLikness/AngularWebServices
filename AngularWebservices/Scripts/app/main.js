(function() {
    var app = angular.module("myApp", ["myApp.services"]);
    app.value('appId', (new Date()).getTime().toString());
    app.config(['$httpProvider', function($httpProvider) {
        $httpProvider.interceptors.push('myInterceptor');
    }]);
})();