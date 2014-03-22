(function (app) {

    function Controller(httpService) {
        var _this = this;
        this.httpService = httpService;
        this.error = false;
        this._reset();
        httpService.subscribe(function () {
            _this.listContacts();
        });
        this.contacts = [];
    }

    Controller.prototype._reset = function() {
        this.successMsg = '';
        this.errorMsg = '';
    };

    Controller.prototype.listContacts = function () {
        var _this = this;
        this.error = false;
        this.httpService.listContacts().then(function (list) {
            _this.contacts = list;            
        },
            function () {
                _this.error = true;
            });
    };

    Controller.prototype.delete = function (contact) {
        var _this = this;
        this._reset();
        this.httpService.deleteContact(contact.id)
            .then(function () {
                _this.successMsg = "Deleted contact with id " + contact.id;
            }, function() {
                _this.errorMsg = "There was an error deleting the contact.";
            });
    };
    
    Controller.prototype.swap = function (contact) {
        var update = angular.extend({}, contact);
        var _this = this;
        this._reset();
        update.firstName = contact.lastName;
        update.lastName = contact.firstName; 
        this.httpService.updateContact(update)
            .then(function () {
                _this.successMsg = "Swapped first name and last name for contact with id " + contact.id;
            }, function () {
                _this.errorMsg = "There was an error updating the contact.";
            });
    };

    Controller.$inject = ['httpService'];

    app.controller("listCtrl", Controller);

})(angular.module("myApp"));