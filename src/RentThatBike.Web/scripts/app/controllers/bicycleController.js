(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('BicycleController', ['$scope', '$location', '$routeParams', 'bicyclesService', 'usSpinnerService',
        function ($scope, $location, $routeParams, bicyclesService, usSpinnerService) {
            $scope.isNew = !$routeParams.bicycleId;

            $scope.bicycleTypes = bicyclesService.getBicycleTypes();

            var originalBicyle = null;

            if ($scope.isNew) {
                $scope.formTitle = "Add new bicycle";
                $scope.bicycle = bicyclesService.createBicycle();
            } else {
                $scope.formTitle = "Update bicycle";
                usSpinnerService.spin("mainSpinner");
                originalBicyle = bicyclesService.getBicycle($routeParams.bicycleId);
                originalBicyle.$promise.then(function () {
                    $scope.bicycle = angular.copy(originalBicyle);
                    usSpinnerService.stop("mainSpinner");
                });
            }

            $scope.submit = function () {
                if ($scope.isNew) {
                    usSpinnerService.spin("mainSpinner");
                    bicyclesService
                        .addBicycle($scope.bicycle)
                        .then(function () {
                            usSpinnerService.stop("mainSpinner");
                            $location.path('/bicycles');
                        });

                } else {
                    angular.copy($scope.bicycle, originalBicyle);
                    usSpinnerService.spin("mainSpinner");
                    originalBicyle = bicyclesService.updateBicycle(originalBicyle);
                    originalBicyle.$promise.then(function () {
                        usSpinnerService.stop("mainSpinner");
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