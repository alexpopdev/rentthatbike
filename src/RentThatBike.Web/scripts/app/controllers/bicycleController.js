(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('BicycleController', ['$scope', '$location', '$routeParams', 'bicyclesService',
            function ($scope, $location, $routeParams, bicyclesService) {
                $scope.isNew = !$routeParams.bicycleId;

                $scope.bicycleTypes = bicyclesService.getBicycleTypes();

                var originalBicyle = null;

                if ($scope.isNew) {
                    $scope.bicycle = bicyclesService.createBicycle();
                    $scope.formTitle = "Add new bicycle";
                } else {
                    originalBicyle = bicyclesService.getBicycle($routeParams.bicycleId);
                    $scope.bicycle = angular.copy(originalBicyle);
                    $scope.formTitle = "Update bicycle";
                }

                $scope.submit = function () {
                    if ($scope.isNew) {
                        bicyclesService.addBicycle($scope.bicycle);
                    } else {
                        angular.copy($scope.bicycle, originalBicyle);
                        bicyclesService.updateBicycle(originalBicyle);
                    }

                    $location.path('/bicycles');
                };

                $scope.cancel = function() {
                    $location.path('/bicycles');
                };
            }
    ]);
})();