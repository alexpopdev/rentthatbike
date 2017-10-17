(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.factory('feedbacksService', ['$resource', function ($resource) {
        var FeedbackResource = $resource('http://localhost:53030/feedbacks');
        return {
            createFeedback: function () {
                return new FeedbackResource({});
            },
            addFeedback: function (feedback) {
                return feedback.$save();
            }
        };
    }]);
})();