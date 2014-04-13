(function () {
    "use strict";

    var myAppModule = angular.module('myApp');
    
    myAppModule.factory('playerService', function () {
        var playerIndex = 0;
        return {
            createPlayer: function () {
                playerIndex += 1;
                return {
                    id: playerIndex,
                    name: "Player" + playerIndex
                };
            },
            resetPlayerCount: function() {
                playerIndex = 0;
            }
        };
    });
})();