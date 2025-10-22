document.addEventListener('DOMContentLoaded', function () {
    const contactBtn = document.getElementById('contact-btn');
    const modal = document.getElementById('contact-modal');
    const closeBtn = document.getElementById('modal-close-btn');
    const contactForm = document.getElementById('contact-form');
    const formContent = document.getElementById('form-content');
    const successMessage = document.getElementById('success-message');

    if (!contactBtn || !modal || !closeBtn || !contactForm) return;

    // --- Modal Logic ---
    function openModal() { modal.classList.add('active'); }
    function closeModal() { modal.classList.remove('active'); }

    contactBtn.addEventListener('click', openModal);
    closeBtn.addEventListener('click', closeModal);
    modal.addEventListener('click', (e) => {
        if (e.target === modal) {
            closeModal();
        }
    });

    // --- Formspree Submission Logic ---
    contactForm.addEventListener('submit', function (e) {
        e.preventDefault(); // Prevent default page reload

        const formData = new FormData(contactForm);
        const submitButton = contactForm.querySelector('button[type="submit"]');
        submitButton.textContent = "Submitting...";
        submitButton.disabled = true;

        fetch(contactForm.action, {
            method: 'POST',
            body: formData,
            headers: {
                'Accept': 'application/json'
            }
        }).then(response => {
            if (response.ok) {
                // Show success message and start auto-close timer
                formContent.style.display = 'none';
                successMessage.style.display = 'block';
                setTimeout(() => {
                    closeModal();
                    // Reset form for next time
                    contactForm.reset();
                    formContent.style.display = 'block';
                    successMessage.style.display = 'none';
                    submitButton.textContent = "Submit Suggestion";
                    submitButton.disabled = false;
                }, 10000); // Close after 10 seconds
            } else {
                // Handle server errors
                response.json().then(data => {
                    if (Object.hasOwn(data, 'errors')) {
                        alert(data["errors"].map(error => error["message"]).join(", "));
                    } else {
                        alert('Oops! There was a problem submitting your form');
                    }
                    submitButton.textContent = "Submit Suggestion";
                    submitButton.disabled = false;
                });
            }
        }).catch(error => {
            // Handle network errors
            alert('Oops! There was a network problem.');
            submitButton.textContent = "Submit Suggestion";
            submitButton.disabled = false;
        });
    });
}); 