(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('ApplicationController', ['$scope', 'serverSideData',
            function ($scope, serverSideData) {
                $scope.isMainMenuCollapsed = false;
                $scope.serverSideData = serverSideData;
            }
    ]);
})();