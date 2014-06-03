(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('FeedbackController', ['$scope', '$location', 'feedbacksService',
        function ($scope, $location, feedbacksService) {
            $scope.formTitle = "Send feedback";
            $scope.feedback = feedbacksService.createFeedback();

            $scope.submit = function () {
                feedbacksService
                    .addFeedback($scope.feedback)
                    .then(function () {
                    alert("Feedback with id " + $scope.feedback.id + " was created.");
                        $location.path('/');
                    });
            };

            $scope.cancel = function () {
                $location.path('/');
            };
        }
    ]);
})();