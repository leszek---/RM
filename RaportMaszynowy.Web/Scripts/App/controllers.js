angular.module('app.controllers', [])

    .controller('ItemController', ['$scope', '$location', '$window', '$http', function ($scope, $location, $window, $http) {
        var apiurl = "api/ItemApi";
        init(apiurl);
        $scope.items = [];
        $scope.init = false;


    function changeStatus (id , status) {
        
    }


        function init(apiurl) {


            return $http.get(apiurl).
  success(function (data, status, headers, config) {

      $scope.items = data;

  }).
  error(function (data, status, headers, config) {
      alert("Wystąpil blad zrestartuj aplikacje");
  });



        }
    }])