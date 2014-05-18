'use strict';

describe("bicyclesController", function () {

    beforeEach(module('myApp'));

    it('should be defined', inject(function ($controller) {
        var bicyclesController = $controller('BicyclesController', { $scope: {} });
        expect(bicyclesController).toBeDefined();
    }));

    it('should have 0 bicycles', inject(function ($controller) {
        var $scope = {};
        $controller('BicyclesController', { $scope: $scope, bicyclesService: { getBicycles: function (){ return []; }} });
        expect($scope.bicycles).toBeDefined();
        expect($scope.bicycles.length).toEqual(0);
    }));
});