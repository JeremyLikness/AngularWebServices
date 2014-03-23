(function (app, url) {

    function Service($resource, $q) {
        this._url = url;
        this.ContactTemplate = $resource(
            url + ":contactId",
            { contactId: '@id' },
            { 'update': { method: 'PUT' } });
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
        var newContact = new this.ContactTemplate(contact);
        newContact.$save(function() {
            deferred.resolve(newContact);
            _this.publish();
        }, function(rejection) {
            deferred.reject(rejection);
        });
        return deferred.promise;
    };

    Service.prototype.listContacts = function () {
        var deferred = this._$q.defer(),
            query = this.ContactTemplate.query(function() {
                deferred.resolve(query);
            }, function(rejection) {
                deferred.reject(rejection);
            });
        return deferred.promise;
    };

    Service.prototype.deleteContact = function (id) {
        var deferred = this._$q.defer(), _this = this,
            contact = new this.ContactTemplate({ id: id });
        contact.$delete(function () {
            deferred.resolve();
            _this.publish();
        }, function (rejection) {
            deferred.reject(rejection);
        });
        return deferred.promise;
    };

    Service.prototype.updateContact = function (contact) {
        var deferred = this._$q.defer(),
            _this = this;
        contact.$update(function () {
            deferred.resolve();
            _this.publish();
        }, function (rejection) {
            deferred.reject(rejection);
        });
        return deferred.promise;
    };

    Service.$inject = ['$resource', '$q'];

    app.service("contactService", Service);
})(angular.module("myApp.services", ['ngResource']), "/api/contacts/")