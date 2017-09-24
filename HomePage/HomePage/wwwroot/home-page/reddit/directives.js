angular.module("homePage").directive('redditMain',function(){
    return {
        templateUrl:"/home-page/reddit/partials/redditIndex.html",
        controller: "redditCtrl",
        controllerAs: "vm"
    }
});