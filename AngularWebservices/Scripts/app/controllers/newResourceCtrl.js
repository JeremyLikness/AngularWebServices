(function (app) {

    function Controller($resource, $scope) {
        this.Contact = $resource('/api/contacts/:contactId', { contactId:'@id'});
        this.$scope = $scope;
        this.error = false;
        this.success = false;
    }

    Controller.prototype.addContact = function () {
        var newContact = new this.Contact();
        this.error = false;
        newContact.firstName = this.firstName;
        newContact.lastName = this.lastName;
        newContact.$save();
        this.id = newContact.id;
        this.success = true;
        this.firstName = '';
        this.lastName = '';
        this.$scope.newUser.$setPristine();
    };

    Controller.$inject = ['$resource', '$scope'];

    app.controller("newCtrl", Controller);

})(angular.module("myApp"));