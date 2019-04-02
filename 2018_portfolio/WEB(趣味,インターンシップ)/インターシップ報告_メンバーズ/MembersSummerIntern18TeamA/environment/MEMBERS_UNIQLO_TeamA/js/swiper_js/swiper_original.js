
var mySwiper1 = new Swiper ('.swiper-container1', {
  loop: true,

  slidesPerView: 2,
  spaceBetween: 10,
  centeredSlides : true,
  pagination: {
      el:'.swiper-pagination',
      type:'bullets',},
  nextEl: '.swiper-button-next',
  prevEl: '.swiper-button-prev',
  autoplay: {
    delay: 3000,
    disableOnInteraction: true
  },
  simulateTouch: true,
});


// var mySwiper = new Swiper ('.swiper-container', {
//   loop: true,
//   slidesPerView: 2,
//   spaceBetween: 30,
//   centeredSlides : true,
//   pagination: '.swiper-pagination',
//   nextButton: '.swiper-button-next',
//   prevButton: '.swiper-button-prev'
// })