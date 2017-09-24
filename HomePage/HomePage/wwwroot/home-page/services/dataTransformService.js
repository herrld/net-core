
var injectParams=[];
var dataTransformService = function(){
    this.redditToItems =function(redditData){
        var transformedItems = [];
        redditData.forEach(function(element) {
            
            var newItem = {
                title : element.data.title,
                thumbnail :element.data.thumbnail !== "default" ? element.data.thumbnail: "/home-page/resources/images/default.jpg",
                link:element.data.permalink
            };
            transformedItems.push(newItem);
        }, this);
        return transformedItems;
    };
};

dataTransformService.$inject = injectParams;

angular.module("homePage").service("dataTransformService",dataTransformService);