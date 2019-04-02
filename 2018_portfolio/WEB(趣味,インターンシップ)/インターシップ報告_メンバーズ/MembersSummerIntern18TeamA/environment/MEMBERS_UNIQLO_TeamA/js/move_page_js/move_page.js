// $(function(){
// 	$('a[id=odekake]').click(function(){ 
//         var speed = 50; //移動完了までの時間(sec)を指定
//         var href= $(this).attr("href"); 
//         var target = $(href == "#" || href == "" ? 'html' : href);
//         var position = target.offset().top;
//         $("html, body").animate({scrollTop:position}, speed, "swing");
//         return false;
//     });

//     $('a[id=joshikai]').click(function(){ 
//         var speed = 50; //移動完了までの時間(sec)を指定
//         var href= $(this).attr("href"); 
//         var target = $(href == "#" || href == "" ? 'html' : href);
//         var position = target.offset().top;
//         $("html, body").animate({scrollTop:position}, speed, "swing");
//         return false;
//     });

// $('a[id=danshikai]').click(function(){ 
//         var speed = 50; //移動完了までの時間(sec)を指定
//         var href= $(this).attr("href"); 
//         var target = $(href == "#" || href == "" ? 'html' : href);
//         var position = target.offset().top;
//         $("html, body").animate({scrollTop:position}, speed, "swing");
//         return false;
//     });
// });

$(function(){
	$('a[id=odekake_joshi]').click(function(){ 
        var speed = 50; //移動完了までの時間(sec)を指定
        var href= $(this).attr("href"); 
        var target = $(href == "#" || href == "" ? 'html' : href);
        var position = target.offset().top;
        $("html, body").animate({scrollTop:position}, speed, "swing");
        return false;
    });

    $('a[id=joshikai]').click(function(){ 
        var speed = 50; //移動完了までの時間(sec)を指定
        var href= $(this).attr("href"); 
        var target = $(href == "#" || href == "" ? 'html' : href);
        var position = target.offset().top;
        $("html, body").animate({scrollTop:position}, speed, "swing");
        return false;
    });

$('a[id=odekake_danshi]').click(function(){ 
        var speed = 50; //移動完了までの時間(sec)を指定
        var href= $(this).attr("href"); 
        var target = $(href == "#" || href == "" ? 'html' : href);
        var position = target.offset().top;
        $("html, body").animate({scrollTop:position}, speed, "swing");
        return false;
    });

$('a[id=danshikai]').click(function(){ 
        var speed = 50; //移動完了までの時間(sec)を指定
        var href= $(this).attr("href"); 
        var target = $(href == "#" || href == "" ? 'html' : href);
        var position = target.offset().top;
        $("html, body").animate({scrollTop:position}, speed, "swing");
        return false;
    });
});