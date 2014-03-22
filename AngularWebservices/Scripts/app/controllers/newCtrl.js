(function(app) {

    function Controller(httpService, $scope) {
        this.httpService = httpService;
        this.$scope = $scope;
        this.error = false;
        this.success = false;
    }

    Controller.prototype.addContact = function() {
        var _this = this;
        this.success = false;
        this.error = false;
        this.httpService.addContact({
            firstName: this.firstName,
            lastName: this.lastName
        }).then(function (newContact) {
            _this.id = newContact.id;
            _this.success = true;
            _this.firstName = '';
            _this.lastName = '';
            _this.$scope.newUser.$setPristine();
        },
            function() {
                _this.error = true;
            });
    };

    Controller.$inject = ['httpService', '$scope'];

    app.controller("newCtrl", Controller);

})(angular.module("myApp"));