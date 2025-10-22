document.addEventListener('DOMContentLoaded', function () {
    const tabBtns = document.querySelectorAll('.tab-btn');
    const tabPanels = document.querySelectorAll('.tab-panel');

    if (tabBtns.length > 0 && tabPanels.length > 0) {
        tabBtns.forEach(btn => {
            btn.addEventListener('click', () => {
                const targetId = btn.getAttribute('data-target');

                // Update button active state
                tabBtns.forEach(b => b.classList.remove('active'));
                btn.classList.add('active');

                // Update panel active state
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