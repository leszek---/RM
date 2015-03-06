angular.module('app.controllers', [])

    .controller('ItemController', ['$scope', '$location', '$window', '$http', function ($scope, $location, $window, $http) {
        var apiurl = "api/ItemApi";
        var lastData = null;
        $scope.items = [];

        $interval(function () {

        
            $http({
                url: apiurl,
                method: "GET",
                params: { lastData: lastData }
            }).
              success(function (data, status, headers, config) {

                  $scope.items = data;
                  for (var i = 0; i < data.length; i++) {
                      lastData = Array.maxProp(data, 'DateCreated');
                  }

              }).
              error(function (data, status, headers, config) {
                  alert("Wystąpil blad.");
              });

      
        }, 100);



        init(apiurl);




        function changeStatus(id, status) {

        }
    }])