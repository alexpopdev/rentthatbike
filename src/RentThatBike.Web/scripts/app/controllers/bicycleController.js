(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('BicycleController', ['$scope', '$location', 'bicyclesService',
            function ($scope, $location, bicyclesService) {
                $scope.bicycleTypes = bicyclesService.getBicycleTypes();

                $scope.bicycle = bicyclesService.createBicycle();

                $scope.submit = function () {
                    bicyclesService.addBicycle($scope.bicycle);
                    $location.path('/bicycles');
                };
            }
    ]);
})();