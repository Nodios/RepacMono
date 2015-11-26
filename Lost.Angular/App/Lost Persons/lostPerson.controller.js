(function (angular) {
    angular.module("app").controller("LostPersonController",
        ['$scope', '$routeParams', '$window', 'lostPersonService',
        function ($scope, $routeParams, $window, lostPersonService) {

            var vm = $scope.vm = {};

            //varijable
            vm.lostPersons = []; //lost persons

            //metode
            vm.get = function () {
                lostPersonService.getLost();
            }

        }])
})