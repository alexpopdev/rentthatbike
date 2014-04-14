(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('CustomersController', ['$scope', 'customersService',
            function ($scope, customersService) {
                $scope.customers = customersService.getCustomers();
            }
    ]);
})();