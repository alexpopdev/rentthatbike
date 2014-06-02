(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.factory('newsService', ['$resource', function ($resource) {
        var NewsResource = $resource('http://localhost:53030/news', {},
            {
                queryWithJSONP: {
                    method: 'JSONP',
                    params: {
                        callback: 'JSON_CALLBACK'  
                    },
                    isArray: true
                }
            });

        return {
            getNews: function () {
                return NewsResource.queryWithJSONP();
            }
        };
    }]);
})();