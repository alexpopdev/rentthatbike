(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('CustomerController', ['$scope', '$location', '$routeParams', 'customersService',
            function ($scope, $location, $routeParams, customersService) {
                $scope.isNew = !$routeParams.customerId;

                var originalCustomer = null;

                if ($scope.isNew) {
                    $scope.customer = {};
                    $scope.formTitle = "Add new customer";
                } else {
                    originalCustomer = customersService.getCustomer($routeParams.customerId);
                    $scope.customer = angular.copy(originalCustomer);
                    $scope.formTitle = "Update customer";
                }

                $scope.submit = function () {
                    if ($scope.isNew) {
                        customersService.addCustomer($scope.customer);
                    } else {
                        angular.copy($scope.customer, originalCustomer);
                    }

                    $location.path('/customers');
                };

                $scope.cancel = function() {
                    $location.path('/customers');
                };
            }
    ]);
})();