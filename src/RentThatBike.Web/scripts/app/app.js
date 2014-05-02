(function () {
    "use strict";

    var myAppModule = angular.module('myApp', ['ngRoute', 'ngResource', 'ui.bootstrap']);

    myAppModule.config(['$provide', function ($provide) {
        $provide.decorator('$exceptionHandler', ['$delegate', function ($delegate) {
            return function (exception, cause) {
                $delegate(exception, cause);
                alert(exception.message);
            };
        }]);
    }]);

    myAppModule.config([
        '$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
            $routeProvider.when('/', { templateUrl: 'scripts/app/views/default.html' });
            $routeProvider.when('/bicycles', { templateUrl: 'scripts/app/views/bicyclesIndex.html', controller: 'BicyclesController' });
            $routeProvider.when('/bicycles/new', { templateUrl: 'Scripts/app/views/bicyclesEditor.html', controller: 'BicycleController' });
            $routeProvider.when('/bicycles/:bicycleId/edit', { templateUrl: 'Scripts/app/views/bicyclesEditor.html', controller: 'BicycleController' });
            $routeProvider.when('/customers', { templateUrl: 'scripts/app/views/customersIndex.html', controller: 'CustomersController' });
            $routeProvider.when('/customers/new', { templateUrl: 'Scripts/app/views/customerEditor.html', controller: 'CustomerController' });
            $routeProvider.when('/customers/:customerId/edit', { templateUrl: 'Scripts/app/views/customerEditor.html', controller: 'CustomerController' });
            $routeProvider.when('/rentals', { templateUrl: 'scripts/app/views/rentalsIndex.html', controller: 'RentalsController' });
            $routeProvider.when('/rentals/new', { templateUrl: 'Scripts/app/views/rentalsEditor.html', controller: 'RentalController' });
            $routeProvider.when('/rentals/:rentalId/edit', { templateUrl: 'Scripts/app/views/rentalsEditor.html', controller: 'RentalController' });

            $locationProvider.html5Mode(true);
        }
    ]);

})();