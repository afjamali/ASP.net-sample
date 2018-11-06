var app = angular.module('myApp', ['ngRoute']);

app.controller('homeCtrl', function ($scope, $http, $filter) {
    $scope.searchResult = {};   
    $scope.form = {
        firstName: "",
        lastName: "",
        fromDate: "",
        toDate: "",
        orderType: ""
    };
    $scope.search = function () {
        //$scope.form.fromDate = $filter('date')($scope.form.fromDate, "yyyy-MM-dd HH:mm:ss");
        //$scope.form.toDate = $filter('date')($scope.form.toDate, "yyyy-MM-dd HH:mm:ss");
        $http.get('Home/Search', {
            params: {
                firstName: $scope.form.firstName,
                lastName: $scope.form.lastName,
                fromDate: $scope.form.fromDate,
                toDate: $scope.form.toDate,
                orderType: $scope.form.orderType
            }
        })
            .then(function (response) {
                $scope.searchResult = response.data;
            });
    };
});

app.controller('productCtrl', function ($scope, $http) {
    $scope.detail = {};
    $scope.info = function () {
        $http.get('OrderInfo')
            .then(function (response) {
                $scope.detail = response.data;
            });
    };
    $scope.info();
});