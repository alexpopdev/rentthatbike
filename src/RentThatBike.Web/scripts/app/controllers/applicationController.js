(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('ApplicationController', ['$scope', 'serverSideData', 'tmhDynamicLocale', 
            function ($scope, serverSideData, tmhDynamicLocale) {
                $scope.isMainMenuCollapsed = false;
                $scope.serverSideData = serverSideData;
                $scope.supportedLocales = ['en-us', 'en-gb', 'fr-fr'];
                
                $scope.onLocaleChanged = function(index) {
                    $scope.selectedLocale = $scope.supportedLocales[index];
                    tmhDynamicLocale.set($scope.selectedLocale);
                };

                $scope.onLocaleChanged(0);
            }
    ]);
})();