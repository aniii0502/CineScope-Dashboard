document.addEventListener('DOMContentLoaded', function () {

    // --- TRAILER MODAL LOGIC ---
    const playBtn = document.getElementById('play-trailer-btn');
    const modal = document.getElementById('trailer-modal');
    const closeBtn = document.getElementById('modal-close-btn');
    const player = document.getElementById('youtube-player');

    if (playBtn && modal && closeBtn && player) {
        const openModal = () => {
            const trailerKey = playBtn.getAttribute('data-trailer-key');
            if (trailerKey) {
                player.src = `https://www.youtube.com/embed/${trailerKey}?autoplay=1`;
                modal.classList.add('active');
            }
        };
        const closeModal = () => {
            modal.classList.remove('active');
            player.src = ''; // Stop video
        };
        playBtn.addEventListener('click', openModal);
        closeBtn.addEventListener('click', closeModal);
        modal.addEventListener('click', (e) => e.target === modal && closeModal());
    }

    // --- SHARE BUTTON LOGIC ---
    const shareBtn = document.getElementById('share-btn');
    const shareMenu = document.getElementById('share-menu');

    if (shareBtn && shareMenu) {
        shareBtn.addEventListener('click', (e) => {
            e.stopPropagation();
            const isActive = shareMenu.classList.toggle('active');
            if (isActive) {
                const url = window.location.href;
                const text = `Check out this series: ${document.title}`;
                document.getElementById('share-twitter').href = `https://twitter.com/intent/tweet?url=${encodeURIComponent(url)}&text=${encodeURIComponent(text)}`;
                document.getElementById('share-facebook').href = `https://www.facebook.com/sharer/sharer.php?u=${encodeURIComponent(url)}`;
            }
        });
        const copyLinkBtn = document.getElementById('copy-link-btn');
        copyLinkBtn.addEventListener('click', () => {
            navigator.clipboard.writeText(window.location.href).then(() => {
                copyLinkBtn.innerHTML = '<i class="fa fa-check"></i>';
                setTimeout(() => { copyLinkBtn.innerHTML = '<i class="fa fa-link"></i>'; }, 2000);
            });
        });
        document.addEventListener('click', () => shareMenu.classList.remove('active'));
    }

    // --- TABS LOGIC ---
    const tabBtns = document.querySelectorAll('.tab-btn');
    const tabPanels = document.querySelectorAll('.tab-panel');

    if (tabBtns.length > 0 && tabPanels.length > 0) {
        tabBtns.forEach(btn => {
            btn.addEventListener('click', () => {
                const targetId = btn.getAttribute('data-target');

                tabBtns.forEach(b => b.classList.remove('active'));
                btn.classList.add('active');

                tabPanels.forEach(panel => {
                    if (`#${panel.id}` === targetId) {
                        panel.classList.add('active');
                    } else {
                        panel.classList.remove('active');
                    }
                });
            });
        });
    }
});