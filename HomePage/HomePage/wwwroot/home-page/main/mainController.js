
var injectParams = ["$http"]
var mainController = function ($http) {

}

mainController.$inject = injectParams;
angular.module('homePage').controller("mainCtrl", mainController);
