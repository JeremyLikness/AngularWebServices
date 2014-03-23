(function(app) {
    app.factory('myInterceptor', ['$q', 'appId', function ($q, appId) {
        return {
            response: function (response) {
                var idx;
                if (response && response.data && angular.isArray(response.data)) {
                    for (idx = 0; idx < response.data.length; idx++) {
                        response.data[idx].$appId = appId; 
                    }
                }
                return response || $q.when(response);
            },
            responseError: function (rejection) {
                console.log(rejection);
                $q.reject(rejection);
            },
            request: function(request) {
                request.headers['App-Id'] = appId;
                return request || $q.when(request);                
            },
            requestError: function (rejection) {
                console.log(rejection);
                $q.reject(rejection);
            }
        };
    }]);
})(angular.module("myApp"));