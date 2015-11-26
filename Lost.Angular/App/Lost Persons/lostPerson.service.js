(function (angular) {
    angular.module("app").service("lostPersonService",
        ['$http', '$window', 'routePrefix',
            function ($http, $window, routePrefix) {
                return {

                    //GET data
                    getLost: function () {
                        return $http.get(routePrefix.lost);
                    }
                }
            }
    ]);
})(angular)