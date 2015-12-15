var adminSiteApp = angular.module('adminSiteApp', ['ngRoute']);

adminSiteApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/product', {
        templateUrl: 'Partials/Public/Product.html',
        controller: 'ProductCtrl'
    }).otherwise({
        redirectTo: '/home'
    });
}]);

adminSiteApp.controller('ProductCtrl', ['$scope', '$http', function ($scope, $http) {
    /** create $scope.template **/
    $scope.template = {
        "Left": "Partials/Public/ProductLeft.html",
        "Content": "Partials/Public/ProductContent.html",
        "Right": "Partials/Public/ProductRight.html"
    }

    $scope.message = {
        "Left": "Message from test1 template",
        "Content": "Message from test2 template",
        "Right": "Message from test3 template"
    }
}]);