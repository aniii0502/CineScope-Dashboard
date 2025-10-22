document.addEventListener('DOMContentLoaded', function () {
    const slides = document.querySelectorAll('.hero-slider .slide');
    const nextBtn = document.getElementById('slider-next');
    const prevBtn = document.getElementById('slider-prev');

    if (slides.length === 0) return;

    let currentSlide = 0;
    let slideInterval;

    function showSlide(index) {
        slides.forEach((slide, i) => {
            slide.classList.remove('active');
            if (i === index) {
                slide.classList.add('active');
            }
        });
    }

    function nextSlide() {
        currentSlide = (currentSlide + 1) % slides.length;
        showSlide(currentSlide);
    }

    function prevSlide() {
        currentSlide = (currentSlide - 1 + slides.length) % slides.length;
        showSlide(currentSlide);
    }

    function startSlider() {
        slideInterval = setInterval(nextSlide, 7000); // Change slide every 7 seconds
    }

    function resetSliderInterval() {
        clearInterval(slideInterval);
        startSlider();
    }

    if (nextBtn && prevBtn) {
        nextBtn.addEventListener('click', () => {
            nextSlide();
            resetSliderInterval();
        });

        prevBtn.addEventListener('click', () => {
            prevSlide();
            resetSliderInterval();
        });
    }

    // Initialize slider
    showSlide(currentSlide);
    startSlider();
});