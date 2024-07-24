/* const slider = () => {

    const sliderRef = document.createElement("div");
    const loadingProgress = 0;

    const handleClickNext = () => {
        let items = sliderRef.querySelectorAll(".item");
        sliderRef.appendChild(items[0]);
    };

    const handleClickPrev = () => {
        let items = slideRef.querySelectorAll(".item");
        slideRef.prepend(item[items.length - 1]);

    }

    const data = [

    ]

    const container = document.createElement("div");
    container.classList.add('container');

    const loadbar = document.createElement("div");
    loadbar.classList.add("loadbar");
    loadbar.style.width = '$(loadingProgress)%'

    container.appendChild(loadbar);

    container.appendChild(slideRef);

    data.forEach((item) => {
        const slideitem = document.createElement("div");
        slideitem.classList.add("item");
        slideitem.styke.backgourndImage = 'url(${item.imgUrl})';

        const content = document.createElement("div");
        content.classList.add("content");

        const name = document.createElement("div");
        name.classList.add("name");
        name.textContent = item.name;

        const des = document.createElement("div");
        des.classList.add("des");
        des.textContent = item.desc;
    });

    document.getElementById("root").appendChild(container);
};

slider(); */

/*
Slider option 1 
let slideIndex = 1;
showSlides(slideIndex);

// Next/prev controls
function plusSlides(n) {
    showSlides(slideIndex += n);
}

// Thumbnail image controls
function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    let i;
    let slides = document.getElementsByClassName("mySlides");
    let dots = document.getElementsByClassName("dot");
    if (n > slides.length) {slideIndex = 1}
    if(n < 1) {slideIndex = slides.length}
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for(i = 0; i < dots.length; i++ ){
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex-1].style.display = "block";
    dots[slideIndex-1].className += " active";
}
*/
/* Slider option 2 */
// automatic slide show
let slideIndex = 0;
showSlides();

function showSlides() {
  let i;
  let slides = document.getElementsByClassName("mySlides");
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  slideIndex++;
  
  if (slideIndex > slides.length) {slideIndex = 1}
  slides[slideIndex-1].style.display = "block";
  setTimeout(showSlides, 4000); // Change image every 2 seconds
}

//mutiple slideshow
/* 
let slideIndex = [1,1];
// Class the members of each slideshow group with different CSS classes 
let slideId = ["mySlides1", "mySlides2"]
showSlides(1, 0);
showSlides(1, 1);

function plusSlides(n, no) {
  showSlides(slideIndex[no] += n, no);
}

function showSlides(n, no) {
  let i;
  let x = document.getElementsByClassName(slideId[no]);
  if (n > x.length) {slideIndex[no] = 1}
  if (n < 1) {slideIndex[no] = x.length}
  for (i = 0; i < x.length; i++) {
    x[i].style.display = "none";
  }
  x[slideIndex[no]-1].style.display = "block";
}
*/

// ------------------- CARD SLIDER --------------------------
// $(document).ready(function(){
//   var noOfProduct =$(".card-slider .card-holder .card-holder__fore") .length;
//   var totalProductWidth = 0;
//   for (var i = 0; i < noOfProduct; i++) {
//     var productWidth = $(".card-slider .card-holder .card-holder__fore").eq(i).outerWidth(true);

//     totalProductWidth = totalProductWidth + productWidth;
//   }

//   $(".card-holder").css('width',totalProductWidth + 'px');

//   var speed = 1;
//   animateProducts();

//   function animateProducts() {
//     $(".card-holder .card-holder__fore").eq(0).animate({
//       'marginLeft' : '-=' +speed+ 'px'
//     },1,function(){
//       var animProductWidth =$(this).outerWidth(true);

//       if(speed >= animProductWidth) {$(this).parent().append($(this)); $(this).removeAttr('style');}

//       aninInterval = setTimeout(function() {
//         animateProducts();
//       });
//     });
//   }

//   $(".card-holder").hover(function() {
//     clearTimeout(aninInterval);
//     $(".card-holder .card-holder__fore").eq(0).stop();
//   }, function() {
//     animateProducts();
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(1)").hover(function() {
//     $(".t1").animate({marginTop: '-80px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(1)").mouseleave(function() {
//     $(".t1").animate({marginTop: '25px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(2)").hover(function() {
//     $(".t2").animate({marginTop: '-80px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(2)").mouseleave(function() {
//     $(".t2").animate({marginTop: '25px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(3)").hover(function() {
//     $(".t3").animate({marginTop: '-80px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(3)").mouseleave(function() {
//     $(".t3").animate({marginTop: '25px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(4)").hover(function() {
//     $(".t4").animate({marginTop: '-80px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(4)").mouseleave(function() {
//     $(".t4").animate({marginTop: '25px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(5)").hover(function() {
//     $(".t5").animate({marginTop: '-80px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(5)").mouseleave(function() {
//     $(".t5").animate({marginTop: '25px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(6)").hover(function() {
//     $(".t6").animate({marginTop: '-80px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(6)").mouseleave(function() {
//     $(".t6").animate({marginTop: '25px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(7)").hover(function() {
//     $(".t7").animate({marginTop: '-80px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(7)").mouseleave(function() {
//     $(".t7").animate({marginTop: '25px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(8)").hover(function() {
//     $(".t8").animate({marginTop: '-80px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(8)").mouseleave(function() {
//     $(".t8").animate({marginTop: '25px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(9)").hover(function() {
//     $(".t9").animate({marginTop: '-80px'});
//   });

//   $(".card-slider .card-holder .card-holder__fore:nth-child(9)").mouseleave(function() {
//     $(".t9").animate({marginTop: '25px'});
//   });

// });

// BACK TO TOP
const backToTopButton = document.getElementById('back-to-top');

window.addEventListener('scroll', () => {
  if (window.scrollY > 100) {
    backToTopButton.style.display = 'block';
  } else {
    backToTopButton.style.display = 'none';
  }
});

backToTopButton.addEventListener('click', scrollToTop);

function scrollToTop() {
  const startPosition = window.pageYOffset;
  const distance = -startPosition;
  const duration = 500;
  let startTimestamp = null;

  function step(timestamp) {
    if(!startTimestamp) startTimestamp = timestamp;
    const progress = timestamp - startTimestamp;
    window.scrollTo(0, easeInOutCubic(progress, startPosition, distance, duration));
    if(progress < duration) window.requestAnimationFrame(step);
  }
  window.requestAnimationFrame(step);
}

function easeInOutCubic(t, b,c,d) {
  t /= d / 2;
  if (t < 1) return c / 2 * t * t * t + b;
  t -= 2;
  return c / 2 * (t * t * t + 2) + b;
}

// $(document).ready(function() {
//   $('#back-to-top').click(function() {
//     $('body,html').animate({
//       scrollTop: 0
//     }, slow);
//   });
// });