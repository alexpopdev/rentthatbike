(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('BicyclesController', ['$scope', 'bicyclesService', 'usSpinnerService',
            function ($scope, bicyclesService, usSpinnerService) {
                usSpinnerService.spin("mainSpinner");
                $scope.bicycles = bicyclesService.getBicycles();

                $scope.bicycles.$promise.then(function () {
                    usSpinnerService.stop("mainSpinner");
                });
            }
    ]);
})();