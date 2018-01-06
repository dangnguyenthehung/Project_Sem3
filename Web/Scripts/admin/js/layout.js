
jQuery(document).ready(function($) {
    if (localStorage.getItem("activeIndex") == undefined) {
        localStorage.setItem("activeIndex", 0);
    }


    var activeIndex = localStorage.getItem("activeIndex");

    var arr = window.location.href.split('/');
    var pgurl = "/" + arr[3] + "/" + arr[4];

    $(".sidebar-wrapper .nav > li a").each(function() {
        var itemHref = $(this).attr("href");
        //if (pgurl === "/") {
        //    pgurl = "/Admin/Home";
        //};

        if (itemHref == pgurl || itemHref == '')
        //$(this).addClass("active");
            activeIndex = $(".sidebar-wrapper .nav > li").index($(this).parent());
        localStorage.setItem("activeIndex", activeIndex);
    });

    $(".sidebar-wrapper .nav").children().eq(activeIndex).addClass("active");

    $(".sidebar-wrapper .nav li").on("click",
        function() {
            $(".sidebar-wrapper .nav li.active").removeClass("active");
            $(this).addClass("active");
            activeIndex = $(".sidebar-wrapper .nav > li").index(this);
            localStorage.setItem("activeIndex", activeIndex);
        });
})