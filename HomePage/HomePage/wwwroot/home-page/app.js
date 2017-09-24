angular.module('homePage',['ngResource','ngRoute']);

angular.module('homePage').config(["$routeProvider","$locationProvider",function($routeProvider, $locationProvider){
    $locationProvider.html5Mode(true);
    // $routeProvider.when('/',{templateUrl:'/home-page/main/partials/index.html',controller:'mainCtrl'});
    // $routeProvider.when('/',{
    //     templateUrl:'/home-page/main/partials/index.html',controller:'redditCtrl'
    // });
    $routeProvider.when('/',{
        action:"home"
    });
}]);

