(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('RentalsController', ['$scope', 'rentalsService',
            function ($scope, rentalsService) {
                $scope.rentals = rentalsService.getRentals();
            }
    ]);
})();