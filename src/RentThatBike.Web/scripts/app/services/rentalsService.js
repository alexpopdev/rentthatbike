(function() {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.factory('rentalsService', [
        'bicyclesService', 'customersService',
        function(bicyclesService, customersService) {
            var bicycles = bicyclesService.getBicycles();
            var customers = customersService.getCustomers();

            var rentals = [
                { id: 1, startDate: moment().startOf('day').weekday(0).toDate(), endDate: moment().startOf('day').weekday(0).toDate(), bicycleId: bicycles[0].id, bicycle: bicycles[0], quantity: 2, totalPrice: 2 * bicycles[0].rentPrice, paid: false, customerId: customers[0].id, customer: customers[0] },
                { id: 2, startDate: moment().startOf('day').weekday(1).toDate(), endDate: moment().startOf('day').weekday(2).toDate(), bicycleId: bicycles[1].id, bicycle: bicycles[1], quantity: 1, totalPrice: 1 * bicycles[0].rentPrice, paid: true, customerId: customers[1].id, customer: customers[1] }
            ];

            var updateRentalCustomer = function(rental) {
                angular.forEach(customers, function(customer) {
                    if (rental.customerId == customer.id) {
                        rental.customer = customer;
                    }
                });
            };

            var validateRental = function(rental) {
                if (rental.startDate > rental.endDate) {
                    throw new Error("The rental start date cannot be greater than the rental end date!");
                }
            };

            return {
                getRentals: function() {
                    return rentals;
                },
                getRental: function(rentalId) {
                    var existingRental = null;
                    angular.forEach(rentals, function(rental) {
                        if (rental.id == rentalId) {
                            existingRental = rental;
                        }
                    });
                    return existingRental;
                },
                addRental: function(rental) {
                    validateRental(rental);
                    updateRentalCustomer(rental);
                    rental.id = rentals.length + 1;
                    rentals.push(rental);
                },
                updateRental: function(rental) {
                    validateRental(rental);
                    updateRentalCustomer(rental);
                },
                updateRentalBicycle: function(rental) {
                    angular.forEach(bicycles, function (bicycle) {
                        if (rental.bicycleId == bicycle.id) {
                            rental.bicycle = bicycle;
                        }
                    });
                },
                updateRentalTotalPrice: function(rental) {
                    if (!rental.bicycleId) {
                        rental.totalPrice = 0;
                        return;
                    }
                    if (!rental.quantity) {
                        rental.totalPrice = 0;
                        return;
                    }
                    rental.totalPrice = rental.quantity * rental.bicycle.rentPrice;
                }
            };
        }
    ]);
})();