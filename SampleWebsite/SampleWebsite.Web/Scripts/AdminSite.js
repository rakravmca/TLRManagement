var adminSiteApp = angular.module('adminSiteApp', ['ngRoute']);

adminSiteApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/product', {
        templateUrl: 'Partials/Public/Product.html',
        controller: 'ProductCtrl'
    }).when('/stitchingorder', {
        templateUrl: 'Partials/Admin/StitchingOrderList.html',
        controller: 'StitchingOrderListCtrl'
    }).when('/stitchingorder/:id', {
        templateUrl: 'Partials/Admin/StitchingOrderDetail.html',
        controller: 'StitchingOrderDetailCtrl'
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

adminSiteApp.controller('StitchingOrderListCtrl', ['$scope', '$http', function ($scope, $http) {

    /** create $scope.template **/
    $scope.template = {
        "Left": "Partials/Admin/OrderLeft.html",
        "Right": "Partials/Admin/OrderRight.html"
    }

    $scope.message = {
        "Left": "Message from OrderLeft template",
        "Right": "Message from OrderRight template"
    }

    $scope.stitchingOrders = [];
    $scope.stitchingOrderItemInfo = {};
    $scope.paidAmount = 0;
    $scope.currentIndex = 0;

    $scope.LoadStitchingOrders = function () {
        ajaxCall("services/StitchingOrderService.svc/GetStitchingOrders", "GET", {}, function (result) {
            $scope.stitchingOrders = result;
            $scope.$apply();
        });
    }

    $scope.RemoveUser = function (userId) {
        bootbox.confirm("Are you sure?", function (isConfirm) {
            if (isConfirm) {
                $.ajax({
                    url: "services/UserService.svc/RemoveUser",
                    cache: false,
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({ userId: userId }),
                    success: function (result) {
                        if (result) {
                            bootbox.alert("User removed successfully!", function () {
                                $scope.LoadUsers();
                            });
                        }
                    },
                    error: function (xhr) {
                        $scope.isSuccess = false;
                        $scope.errorMsg = $sce.trustAsHtml(xhr.responseText);
                        $scope.$apply();
                    }
                });
            }
        });
    }

    $scope.ShowPaymentModal = function (stitchingOrderInfo) {
        $scope.stitchingOrderItemInfo = stitchingOrderInfo;
        $('#divPaymentModal').modal();
        $scope.paidAmount = 0;
    }

    $scope.MakePayment = function () {
        if ($scope.paymentForm.$valid) {
            $scope.stitchingOrderItemInfo.PaidAmount = parseInt($scope.stitchingOrderItemInfo.PaidAmount) + parseInt($scope.paidAmount);
            $('#divPaymentModal').modal('hide');
            $scope.paidAmount = 0;
        } else {
            // show errors
            angular.forEach($scope.paymentForm.$error, function (value, key) {
                var type = $scope.paymentForm.$error[key];

                angular.forEach(type, function (item) {
                    item.$dirty = true;
                    item.$prestine = false;
                });
            });
        }
    }

    $scope.ShowStatusModal = function (stitchingOrderInfo) {
        $scope.stitchingOrderItemInfo = stitchingOrderInfo;
        $('#divStatusModal').modal()
    }

    $scope.LoadStitchingOrders();
}]);

adminSiteApp.controller('StitchingOrderDetailCtrl', ['$scope', '$routeParams', '$sce', function ($scope, $routeParams, $sce) {

    /** create $scope.template **/
    $scope.template = {
        "Left": "Partials/Admin/OrderLeft.html",
        "Right": "Partials/Admin/OrderRight.html"
    }

    $scope.message = {
        "Left": "Message from OrderLeft template",
        "Right": "Message from OrderRight template"
    }

    $scope.stitchingOrderInfo = {};

    $scope.GetStitchingOrderInfo = function () {
        ajaxCall("services/StitchingOrderService.svc/GetStitchingOrderInfoById?id=" + $routeParams.id, "GET", {}, function (result) {
            $scope.stitchingOrderInfo = result;
            $scope.$apply();
        });
    }

    $scope.SaveStitchingOrder = function () {
        if ($scope.stitchingOrderForm.$valid) {
            var stitchingOrderObj = { stitchingOrderInfo: $scope.stitchingOrderInfo };
            ajaxCall("services/StitchingOrderService.svc/SaveStitchingOrder", "POST", stitchingOrderObj, function (result) {
                if (result) {
                    document.location.href = "#/stitchingorder";
                }
            });
        } else {
            // show errors
            angular.forEach($scope.stitchingOrderForm.$error, function (value, key) {
                var type = $scope.stitchingOrderForm.$error[key];

                angular.forEach(type, function (item) {
                    item.$dirty = true;
                    item.$prestine = false;
                });
            });
        }
    }

    $scope.GetStitchingOrderInfo();
}]);