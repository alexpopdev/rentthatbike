(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('BicycleController', ['$scope', '$location', '$routeParams', 'bicyclesService',
        function ($scope, $location, $routeParams, bicyclesService) {
            $scope.isNew = !$routeParams.bicycleId;

            $scope.bicycleTypes = bicyclesService.getBicycleTypes();

            var originalBicycle = null;

            if ($scope.isNew) {
                $scope.formTitle = "Add new bicycle";
                $scope.bicycle = bicyclesService.createBicycle();
            } else {
                $scope.formTitle = "Update bicycle";
                originalBicycle = bicyclesService.getBicycle($routeParams.bicycleId);
                originalBicycle.$promise.then(function () {
                    $scope.bicycle = angular.copy(originalBicycle);
                });
            }

            $scope.submit = function () {
                if ($scope.isNew) {
                    bicyclesService
                        .addBicycle($scope.bicycle)
                        .then(function () {
                            $location.path('/bicycles');
                        });

                } else {
                    angular.copy($scope.bicycle, originalBicycle);
                    originalBicycle = bicyclesService.updateBicycle(originalBicycle);
                    originalBicycle.$promise.then(function () {
                        $location.path('/bicycles');
                    });
                }
            };

            $scope.cancel = function () {
                $location.path('/bicycles');
            };
        }
    ]);
})();