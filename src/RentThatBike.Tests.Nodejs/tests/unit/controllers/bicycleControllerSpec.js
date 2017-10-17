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

    it('should be in edit bicycle mode for the route with bicycleId set to 1', inject(function ($httpBackend, $controller) {
        var $scope = {};

        $httpBackend.expectGET('api/bicycles/1')
           .respond(200, { id: 1, name: 'testBicycle1' });

        $controller('BicycleController', { $scope: $scope, $routeParams: { bicycleId: 1 } });

        $httpBackend.flush();

        expect($scope.bicycle).toBeDefined();
        expect($scope.formTitle).toEqual("Update bicycle");
        expect($scope.bicycle.id).toEqual(1);

        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    }));
});