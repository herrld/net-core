// site.js

(function () {
    //var main = $("#main");
    //main.on("mouseenter", function () {
    //    main.css("background-color", "#222");
    //});

    //main.on("mouseleave", function () {
    //    main.css("background-color", "");
    //});

    //var menuItems = $("ul.menu li a");
    //menuItems.on("click", function () {
    //    var me = $(this);
    //    alert(me.text());
    //});

    var sidebarAndWrapper = $("#sidebar,#wrapper");
    $("#sidebarToggle").on("click", function () {
        sidebarAndWrapper.toggleClass("hide-sidebar");
        if (sidebarAndWrapper.hasClass("hide-sidebar"))
        {
            $(this).val("Show Sidebar");
        }
        else
        {
            $(this).val("Hide Sidebar");
        }
    });
    
})();
