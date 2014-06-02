(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('NewsController', ['$scope', 'newsService',
            function ($scope, newsService) {
                $scope.news = newsService.getNews();
                $scope.news.$promise.then(function () {
                    if ($scope.news.length > 0) {
                        
                    }
                });
            }
    ]);
})();