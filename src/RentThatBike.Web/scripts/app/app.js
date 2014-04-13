(function () {
    "use strict";

    var myAppModule = angular.module(
        'myApp',
        [
            'ngRoute',
            'ui.bootstrap'
        ]);

    myAppModule.config([
        '$routeProvider', function ($routeProvider) {
            $routeProvider.when('/', { templateUrl: 'scripts/app/views/default.html' });
            $routeProvider.when('/bicycles', { templateUrl: 'scripts/app/views/bicyclesIndex.html' });
            $routeProvider.when('/customers', { templateUrl: 'scripts/app/views/customersIndex.html' });
            $routeProvider.when('/rentals', { templateUrl: 'scripts/app/views/rentalsIndex.html' });
        }
    ]);

})();