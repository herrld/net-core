///// <reference path
var injectParams = ["$scope","$http","dataTransformService"]


var redditController = function($scope, $http, dataTransformService){
    var vm = this;
    var successHandler = function(res){
       $scope.data = dataTransformService.redditToItems(res.data.data.children);
    };
    var errorHandler = function(res){
        var a = res;
    };
    $http.get("/api")
    .then(successHandler,
    errorHandler);
};

redditController.$inject = injectParams;

angular.module("homePage").controller("redditCtrl", redditController);