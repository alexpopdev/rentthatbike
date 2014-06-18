'use strict';

describe("bicyclesController", function () {

    beforeEach(module('myApp'));

    it('should be defined', inject(function ($controller) {
        var bicyclesController = $controller('BicyclesController', { $scope: {} });
        expect(bicyclesController).toBeDefined();
    }));

    it('should have 2 bicycles', inject(function ($httpBackend, $controller) {
        $httpBackend.expectGET('api/bicycles')
              .respond(200, [{ id: 1, name: 'testBicycle1' },
                        { id: 2, name: 'testBicycle2' }]);

        var $scope = {};
        $controller('BicyclesController', { $scope: $scope });

        $httpBackend.flush();

        expect($scope.bicycles).toBeDefined();
        expect($scope.bicycles.length).toEqual(2);
        expect($scope.bicycles[1].name).toEqual("testBicycle2");

        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    }));
});