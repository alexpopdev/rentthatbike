'use strict';

describe("bicycleController", function () {

    beforeEach(module('myApp'));

    it('should be defined', inject(function ($controller) {
        var bicyclesController = $controller('BicycleController', { $scope: {} });
        expect(bicyclesController).toBeDefined();
    }));

    it('should be in create new bicycle mode for the default route', inject(function ($controller) {
        var $scope = {};
        $controller('BicycleController', { $scope: $scope });

        expect($scope.bicycle).toBeDefined();
        expect($scope.formTitle).toEqual("Add new bicycle");
    }));

    it('should be in edit bicycle mode for the route with bicycleId set to 1', inject(function ($controller, $q) {
        var $scope = {};
        var deferred = $q.defer();
        var bicyclesService = {
            getBicycleTypes: function() { return []; },
            getBicycle: function(bicycleId) {
                if (bicycleId == 1) {
                    return deferred;
                }
                return null;
            }
        };
        $controller('BicycleController', { $scope: $scope, $routeParams: { bicycleId: 1}, bicyclesService: bicyclesService });

        expect($scope.bicycle).toBeDefined();
        expect($scope.formTitle).toEqual("Update bicycle");
    }));
});