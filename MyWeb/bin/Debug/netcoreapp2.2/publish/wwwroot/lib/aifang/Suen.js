// JavaScript Document

$(function(){
	function imgs (){
			var imgsW= $(".imgs").width();
				$(".imgs").css({"height":imgsW*3/4+"px"});
		var pmW = $(window).width();
		var contai = $(".container-fluid").width();
		var lefts = (pmW-contai)/2-96;
		$(".banner .carousel-control.left").css({"left":lefts+"px"});
		$(".banner .carousel-control.right").css({"right":lefts+"px"});
		if ( pmW <= 991 ){
			$('header nav').hide();
			$('body').removeClass('hover');
		}else{
			$('header nav').show();
			$('body').addClass('hover');
		}

				
		var p30H = $('.pictrue30 a .imgbox span').height();
		$('.pictrue30 a .imgbox span').css({"line-height":p30H+"px"});
		var p11_viewW = $('.pictrue11 .pc-slide').width();
		$('.pictrue11 .view .swiper-container .swiper-slide').css({"width":p11_viewW+"px"});
		var p11_viewH = $('.pictrue11 .view .swiper-container .swiper-slide a').height();
		$('.pictrue11 .view .swiper-container').css({"height":p11_viewH+"px"});
		$('.pictrue11 .view .swiper-container .swiper-wrapper').css({"height":p11_viewW+"px"});
		$('.pictrue11 .view .swiper-container .swiper-wrapper .swiper-slide').css({"height":p11_viewH+"px"});
		var p11_previewH = $('.pictrue11 .preview .swiper-container .swiper-slide a').height();
		$('.pictrue11 .preview .swiper-container').css({"height":p11_previewH+"px"});
		$('.pictrue11 .preview .swiper-container .swiper-wrapper').css({"height":p11_previewH+"px"});
		$('.pictrue11 .preview .swiper-container .swiper-wrapper .swiper-slide').css({"height":p11_previewH+"px"});



	};
	imgs();	
	$(window).resize(function(){
		imgs();	
	});
	
	
		$(".text3 .closed").click(function(){
			if ( $(this).hasClass("active") ){
				$(this).removeClass("active");
				$(this).find("b").html("打开");
				$(this).prev("ul").slideUp();
			}else{
				$(this).addClass("active");
				$(this).find("b").html("关闭");
				$(this).prev("ul").slideDown();
			}
		});
		
		$("#toolbar a.toolbar-ewm .btn").hover(function(){
			$("#toolbar a.toolbar-ewm .ewm").slideToggle()
		});
		$("header .chengshi .chengshi-btn").on({
			mouseover : function(){
				$("header .chengshi .chengshi-box").show();
				$("header .chengshi .chengshi-btn h4 span").addClass("active");
			},
			click : function(){
				if($("header .chengshi .chengshi-box").is(':hidden')){
					$("header .chengshi .chengshi-box").show();
					$("header .chengshi .chengshi-btn h4 span").addClass("active");
				}else{
					$("header .chengshi .chengshi-box").stop().hide();
					$("header .chengshi .chengshi-btn h4 span").removeClass("active");
				}
			},
		});
		$(".banner").hover(function(){
			$("header .chengshi .chengshi-box").stop().hide();
			$("header .chengshi .chengshi-btn h4 span").removeClass("active");
		})

		$(".pictrue1 .col-xs-4").each(function(i){
			$(".pictrue1 .col-xs-4").eq(i).addClass("col"+i)
		});

	
	for ( var x = 0; x<$("ul").length; x++){
		for( var y=0; y<$("ul").eq(x).find("li").length;y++){
			$("ul").eq(x).find("li").eq(y).addClass("li"+y);
		};
	};
	$(".text2 ul li").each(function(i) {
		if ( i % 3 == 0 ){
			$(".text2 ul li").eq(i).addClass("lia")
		}if ( i % 3 == 1 ){
			$(".text2 ul li").eq(i).addClass("lib")
		}if ( i % 3 == 2 ){
			$(".text2 ul li").eq(i).addClass("lic")
		}
	})
	$(".pictrue1 .col-xs-4").each(function(i){
			$(".pictrue1 .col-xs-4").eq(i).addClass("col"+i)
		});
	$("header nav li").hover(function(){
		$(this).find("ul").slideToggle();	
	});
	$(".ydd_btn").click(function(){
		if($(this).hasClass('click')){
			$(this).removeClass("click");
			$('header .menu nav').stop().slideUp();
		} else{
			$(this).addClass("click");
			$('header .menu nav').slideDown();
		}
	});
	$('.text1 ul li a').click(function(){
		if($('#yijianyuyue').is(':hidden')){
			$('#yijianyuyue-mb').show();
			$('#yijianyuyue').show();
		}
	})
	$('.hot .col-xs-3').eq(1).click(function(){
		if($('#yijianyuyue').is(':hidden')){
			$('#yijianyuyue-mb').show();
			$('#yijianyuyue').show();
			$(this).find('a').removeAttr('href');
		}
	})
	$(".hot .col-xs-3").eq(2).find("a").click(function(){
		$(this).removeAttr('href');
        if ( $(".dbbox .dbs.fenxiang-box").is(':hidden') ){
            $(".dbbox .dbs.fenxiang-box").slideDown();
            $(".dbbox .dbs.ewm-box").slideUp();
        }else{
            $(".dbbox .dbs.fenxiang-box").slideUp();
            
        }
   	}) 
	$('#yijianyuyue-mb').click(function(){
		$(this).hide();
		$('#yijianyuyue').hide();
	})
	$('#yijianyuyue .esc').click(function(){
		$('#yijianyuyue-mb').hide();
		$('#yijianyuyue').hide();
	})
	var ulH = $(".banner .tiaofus .news1 .announcement ul li").length*17;
	$(".announcement ul").css({"height":ulH+"px"});
	var top=parseFloat($(".announcement ul").css("top"));
		function aaa(){
			top-= $(".announcement ul li").height() ;
			if( top==-ulH ){
					top=0;	
			}
			$(".announcement ul").animate({"top":top+"px"},500)
		};
		var s=setInterval(aaa,3000);

	$(".announcement").hover(function(){
		clearInterval(s)
	},function(){
		s=setInterval(aaa,3000)
	})
});

			