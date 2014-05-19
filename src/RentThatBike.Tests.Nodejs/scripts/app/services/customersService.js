(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.factory('customersService', function () {
        var customers = [];

        return {
            getCustomers: function () {
                return customers;
            },
            getCustomer: function (customerId) {
                var existingCustomer = null;
                angular.forEach(customers, function (customer) {
                    if (customer.id == customerId) {
                        existingCustomer = customer;
                    }
                });
                return existingCustomer;
            },
            addCustomer: function (customer) {
                customer.id = customers.length + 1;
                customers.push(customer);
            }
        };
    });
})();