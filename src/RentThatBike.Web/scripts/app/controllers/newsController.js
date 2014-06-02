(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('NewsController', ['$scope', 'newsService',
            function ($scope, newsService) {
                $scope.news = newsService.getNews();
            }
    ]);
})();