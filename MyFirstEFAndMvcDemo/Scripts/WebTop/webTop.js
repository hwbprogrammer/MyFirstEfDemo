$(function ()
{
    $(".MyBackpack").mouseenter(function () {
        $(".MyBackpack").css("background-color", "white");
        $(".MyBackpack").css("border", "1px solid #EEEEEE");
        $(".MyBackpack").css("border-bottom", "0");
        $(".MyBackpackList").css("display", "block");
        $(".webTop").find('span').css('transform', 'rotate(180deg)');
    }).mouseleave(function () {
        $(".webTop").find('span').css('transform', 'rotate(360deg)');
    });
    $(".MyBaoBei").mouseleave(function () {
        $(".MyBackpackList").css("display", "none");
        $(".MyBackpack").css("background-color", "#f2f2f2");
        $(".MyBackpack").css("border", "0");
    });
    $(".webGps").mouseenter(function () {
        $(".webGps").css("background-color", "white");
        $(".webGps").css("border", "1px solid #EEEEEE");
        $(".webGps").css("border-bottom", "0");
        $(".GpsDown").css("display", "block");
    }).mouseleave(function () {
       
    });
    $(".gps").mouseleave(function () {
        $(".GpsDown").css("display", "none");
        $(".webGps").css("background-color", "#f2f2f2");
        $(".webGps").css("border", "0");
    });
    $("#search-kj").focus();//自动获取光标方法
    /*左侧菜单*/
    $('.classify ul li').mouseenter(function () {
        $(this).stop().animate({ height: '250px' }, 300).siblings().stop().animate({ height: '60px' }, 300);
        $(this).siblings().css('background', '#F5F5F5');
        $('.MenuRight').fadeTo(0, 0.8).stop().animate({ width: '290px' }, 300)
    }).mouseleave(function () {
        $(".classify ul li").stop().animate({ height: '79px' }, 300);
        $(this).siblings().css('background', '#ffffff');
    });
    $('.MenuLeft').mouseleave(function () {
        $(".MenuRight").stop().animate({ width: '0px' }, 300)
    });
})