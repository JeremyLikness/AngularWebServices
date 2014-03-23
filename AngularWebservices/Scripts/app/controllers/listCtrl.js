(function (app) {

    function Controller(contactService) {
        var _this = this;
        this.contactService = contactService;
        this.error = false;
        this._reset();
        contactService.subscribe(function () {
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
        this.contactService.listContacts().then(function (list) {
            _this.contacts = list;            
        },
            function () {
                _this.error = true;
            });
    };

    Controller.prototype.delete = function (contact) {
        var _this = this;
        this._reset();
        this.contactService.deleteContact(contact.id)
            .then(function () {
                _this.successMsg = "Deleted contact with id " + contact.id;
            }, function() {
                _this.errorMsg = "There was an error deleting the contact.";
            });
    };
    
    Controller.prototype.swap = function (contact) {
        var firstName = contact.firstName,
            lastName = contact.lastName,
            _this = this;
        this._reset();
        contact.firstName = lastName;
        contact.lastName = firstName;
        this.contactService.updateContact(contact)
            .then(function () {
                _this.successMsg = "Swapped first name and last name for contact with id " + contact.id;
            }, function () {
                _this.errorMsg = "There was an error updating the contact.";
                contact.firstName = firstName;
                contact.lastName = lastName;
            });
    };

    Controller.$inject = ['contactService'];

    app.controller("listCtrl", Controller);

})(angular.module("myApp"));