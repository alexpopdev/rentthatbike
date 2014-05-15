'use strict';

describe("bicyclesController", function () {

    beforeEach(module('myApp'));

    it('should be defined', inject(function ($controller) {
        var bicyclesController = $controller('BicyclesController', { $scope: {} });
        expect(bicyclesController).toBeDefined();
    }));
});