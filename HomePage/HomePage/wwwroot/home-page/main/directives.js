angular.module("homePage").directive('indexMain',function(){
    return {
        templateUrl:"/home-page/main/partials/index.html",
        controller: "mainCtrl",
        controllerAs: "vm"
    };
});