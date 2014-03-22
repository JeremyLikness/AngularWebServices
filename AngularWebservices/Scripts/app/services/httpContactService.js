(function (app, url) {
    
    function Service($http, $q) {
        this._url = url;
        this._$http = $http;
        this._$q = $q;
        this._notify = [];
    }

    Service.prototype.subscribe = function (callback) {
        this._notify.push(callback);
    };

    Service.prototype.publish = function () {
        var i;
        for (i = 0; i < this._notify.length; i++) {
            this._notify[i]();
        }
    };

    Service.prototype.addContact = function (contact) {
        var deferred = this._$q.defer(), _this = this;
        this._$http.post(this._url, contact)
            .then(function (result) {
                deferred.resolve(result.data);
                _this.publish();
            }, function (rejection) {
                deferred.reject(rejection);
            });
        return deferred.promise;
    };

    Service.prototype.listContacts = function () {
        var deferred = this._$q.defer();
        this._$http.get(this._url)
            .then(function (result) {
                deferred.resolve(result.data);
            },
                function (rejection) {
                    deferred.reject(rejection);
                });
        return deferred.promise;
    };

    Service.prototype.deleteContact = function(id) {
        var deferred = this._$q.defer(), _this = this;
        this._$http.delete(this._url + id)
            .then(function () {
                deferred.resolve();
                _this.publish();
            }, function (rejection) {
                deferred.reject(rejection);
            });
        return deferred.promise;
    };
    
    Service.prototype.updateContact = function (contact) {
        var deferred = this._$q.defer(), _this = this;
        this._$http.put(this._url + contact.id, contact)
            .then(function () {
                deferred.resolve();
                _this.publish();
            }, function (rejection) {
                deferred.reject(rejection);
            });
        return deferred.promise;
    };


    Service.$inject = ['$http', '$q'];

    app.service("httpService", Service);
})(angular.module("myApp"), "/api/contacts/")