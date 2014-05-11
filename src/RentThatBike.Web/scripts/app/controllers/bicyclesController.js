(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('BicyclesController', ['$scope', 'bicyclesService',
            function ($scope, bicyclesService) {
                $scope.bicycles = bicyclesService.getBicycles();
            }
    ]);
})();