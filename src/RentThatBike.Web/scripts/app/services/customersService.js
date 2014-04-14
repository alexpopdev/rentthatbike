(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.factory('customersService', function () {
        var customers = [
                    { id: 1, firstName: "Jane", lastName: "Donaldson", email: "jd@test.com", phone: "83782" },
                    { id: 2, firstName: "Kevin", lastName: "Evans", email: "ke@test.com", phone: null },
                    { id: 3, firstName: "Max", lastName: "Donald", email: "md@test.com", phone: "27423" },
                    { id: 4, firstName: "Natalie", lastName: "Hunter", email: "nh@test.com", phone: "56645" }
        ];

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
                customer.id = customer.length;
                customers.push(customer);
            }
        };
    });
})();