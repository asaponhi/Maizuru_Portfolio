var mySwiper2 = new Swiper ('.swiper-container2', {
  loop: true,

  slidesPerView: 2,
  spaceBetween: 10,
  centeredSlides : true,
  pagination: {
      el:'.swiper-pagination',
      type:'bullets',},
 navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
      },
  // nextEl: '.swiper-button-next',
  // prevEl: '.swiper-button-prev',
  autoplay: {
    delay: 3000,
    disableOnInteraction: true
  },
  simulateTouch: true,
  
});