(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('ApplicationController', ['$scope',
            function ($scope) {
                $scope.isMainMenuCollapsed = false;
            }
    ]);
})();