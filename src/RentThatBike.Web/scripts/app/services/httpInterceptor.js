(function () {
    'use strict';

    var serviceId = 'httpInterceptor';

    angular.module('myApp').factory(serviceId, ['$q', 'usSpinnerService', httpInterceptor]);

    function httpInterceptor($q, usSpinnerService) {
        var service = {
            'responseError': function (rejection) {
                var hasErrorMessage = false;
                var errorMessage;
                // check for generic ServiceStack exception
                if (rejection.data && rejection.data.responseStatus && rejection.data.responseStatus.message) {
                    hasErrorMessage = true;
                    errorMessage = rejection.data.responseStatus.message;
                }

                if (hasErrorMessage) {
                    alert("Http response error:" + errorMessage);
                    usSpinnerService.stop("mainSpinner");
                }

                return $q.reject(rejection);
            }
        };

        return service;
    }
})();