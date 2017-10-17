(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('RentalController', ['$scope', '$location', '$routeParams', 'bicyclesService', 'customersService', 'rentalsService',
            function ($scope, $location, $routeParams, bicyclesService, customersService, rentalsService) {
                $scope.isNew = !$routeParams.rentalId;

                $scope.bicycles = bicyclesService.getBicycles();
                $scope.customers = customersService.getCustomers();

                var originalRental = null;

                if ($scope.isNew) {
                    $scope.rental = {};
                    $scope.formTitle = "Add new rental";
                } else {
                    originalRental = rentalsService.getRental($routeParams.rentalId);
                    $scope.rental = angular.copy(originalRental);
                    $scope.formTitle = "Update rental";
                }

                $scope.submit = function () {
                    if ($scope.isNew) {
                        rentalsService.addRental($scope.rental);
                    } else {
                        angular.copy($scope.rental, originalRental);
                        rentalsService.updateRental(originalRental);
                    }

                    $location.path('/rentals');
                };

                $scope.cancel = function() {
                    $location.path('/rentals');
                };

                $scope.updateBicycle = function () {
                    rentalsService.updateRentalBicycle($scope.rental);
                    rentalsService.updateRentalTotalPrice($scope.rental);
                };

                $scope.updateTotalPrice = function() {
                    rentalsService.updateRentalTotalPrice($scope.rental);
                };
            }
    ]);
})();