var viewSwiper = new Swiper('.view .swiper-container', {
  onSlideChangeStart: function() {
    updateNavPosition();
  }
})

$('.view .arrow-left,.preview .arrow-left').on('click', function(e) {
  e.preventDefault();
  if(viewSwiper.activeIndex == 0) {
    viewSwiper.swipeTo(viewSwiper.slides.length - 1, 1000);
    return;
  }
  viewSwiper.swipePrev();
})
$('.view .arrow-right,.preview .arrow-right').on('click', function(e) {
  e.preventDefault();
  if(viewSwiper.activeIndex == viewSwiper.slides.length - 1) {
    viewSwiper.swipeTo(0, 1000);
    return
  }
  viewSwiper.swipeNext();
})

var previewSwiper = new Swiper('.preview .swiper-container', {
  visibilityFullFit: true,
  slidesPerView: 'auto',
  onlyExternal: true,
  slidesPerView:5,
  onSlideClick: function() {
    viewSwiper.swipeTo(previewSwiper.clickedSlideIndex);
  }
})

function updateNavPosition() {
  $('.preview .active-nav').removeClass('active-nav');
  var activeNav = $('.preview .swiper-slide').eq(viewSwiper.activeIndex).addClass('active-nav');
  if(!activeNav.hasClass('swiper-slide-visible')) {
    if(activeNav.index() > previewSwiper.activeIndex) {
      var thumbsPerNav = Math.floor(previewSwiper.width / activeNav.width()) - 1;
      previewSwiper.swipeTo(activeNav.index() - thumbsPerNav);
    } else {
      previewSwiper.swipeTo(activeNav.index());
    }
  }
}