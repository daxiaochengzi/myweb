// JavaScript Document

$(document).ready(function() {
	$(".pictrue30-owl").owlCarousel({
		items : 1,/*默认显示数量*/
		itemsDesktop : [1199, 1],/*响应式布局*/
		itemsDesktopSmall : [991, 1],
		itemsTablet : [768, 1],
		itemsMobile : [479, 1],
		autoPlay : 3000,
		stopOnHover : true,/*鼠标经过悬停*/
		lazyLoad : true,/*响应式开关*/
		navigation : false,/*箭头开关*/
		pagination : true,/*按钮开关*/
		navigationText : ["", ""],/*左右箭头文字*/
	  })
 })
$(document).ready(function() {
	$(".pictrue-11-owl").owlCarousel({
		items : 5,/*默认显示数量*/
		itemsDesktop : [1199, 4],/*响应式布局*/
		itemsDesktopSmall : [991, 4],
		itemsTablet : [768, 4],
		itemsMobile : [479, 3],
		autoPlay : 3000,
		stopOnHover : true,/*鼠标经过悬停*/
		lazyLoad : true,/*响应式开关*/
		navigation : true,/*箭头开关*/
		pagination : false,/*按钮开关*/
		navigationText : ["", ""],/*左右箭头文字*/
	  });
 });