(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.factory('newsService', ['$resource', function ($resource) {
        var NewsResource = $resource('http://localhost:53030/news');
     
        return {
            getNews: function () {
                return NewsResource.query();
            }
        };
    }]);
})();