angular.module('app.controllers', [])

    .controller('ItemController', ['$scope', '$location', '$window', '$http', function ($scope, $location, $window, $http) {
        var apiurl = "api/Item/get";
        init(apiurl);
        $scope.items = [];

        $scope.init = false;


        function init(apiurl) {


            return $http.get(apiurl);



        }
    }])