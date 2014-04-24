(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.factory('bicyclesService', ['$resource', function ($resource) {
        var bicycleTypes = [{ id: 1, name: "Road Bike" }, { id: 2, name: "Mountain Bike" }, { id: 3, name: "Urban Bike" }, { id: 4, name: "Children Bike" }];

        var BicyclesResource = $resource('bicycles/:bicycleId', null,
            {
                'add': { method: 'POST' },
                'update': { method: 'PUT' }
            });

        var updateBicycleTypeName = function (bicycle) {
            angular.forEach(bicycleTypes, function (bicycleType) {
                if (bicycleType.id == bicycle.type) {
                    bicycle.typeName = bicycleType.name;
                }
            });
        };

        return {
            getBicycles: function () {
                return BicyclesResource.query();
            },
            getBicycle: function (bicycleId) {
                return BicyclesResource.get({ bicycleId: bicycleId });
            },
            getBicycleTypes: function () {
                return bicycleTypes;
            },
            createBicycle: function () {
                return {
                    type: bicycleTypes[0].id,
                    typeName: bicycleTypes[0].name,
                    quantity: 1,
                    rentPrice: 10
                };
            },
            addBicycle: function (bicycle) {
                updateBicycleTypeName(bicycle);
                return BicyclesResource.add(null, { bicycle: bicycle });
            },
            updateBicycle: function (bicycle) {
                updateBicycleTypeName(bicycle);
                return BicyclesResource.update({ bicycleId: bicycle.id }, { bicycle: bicycle });
            }
        };
    }]);
})();