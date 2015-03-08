angular.module('app.controllers', [])

    .controller('ItemController', ['$scope', '$location', '$window', '$http', '$interval', function ($scope, $location, $window, $http, $interval) {
        var getItemApiurl = "api/ItemApi/GetItems";
    var upateIemApiUrl = "api/ItemApi/UpdateItem";
    var error = false;
    var lock = false;
        var lastData = null;
        $scope.items = [];

        $interval(function () {

                
                var request = {
                    LastDate: lastData
                };
                $http({
                    url: getItemApiurl,
                        method: "Post",
                        data: request 
                    }).
                    success(function(data, status, headers, config) {

                        if (data != null) {
                            for (var i = 0; i < data.length  ; i++) {
                                $scope.items.push(data[i]);
                            }
                            if (data.length - 1 >= 0) {
                                lastData = data[data.length - 1].DateCreated;
                            }
                          
                        }

                    }).
                    error(function(data, status, headers, config) {
                      
            
                    });
            


        }, 2000);


    $scope.changeStatus = function(item) {
        if (item.Status == true) {
            item.Status = false;
        } else {
            item.Status = true;
        }


        $http({
            url: upateIemApiUrl,
            method: "Post",
            data: item
        }).
                   success(function (data, status, headers, config) {

                   }).
                   error(function (data, status, headers, config) {
                       alert("Wystąpil blad.");
                   
                   });


    };
}])