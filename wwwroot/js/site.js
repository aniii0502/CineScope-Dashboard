// ========================
// SITE.JS - CineScope
// ========================

document.addEventListener('DOMContentLoaded', function () {

    // ------------------------
    // Theme Toggle
    // ------------------------
    const html = document.documentElement;
    const themeToggle = document.getElementById('theme-toggle');

    function updateThemeIcon() {
        if (themeToggle) {
            themeToggle.innerHTML = html.dataset.theme === 'dark' ? '<i class="fa fa-sun"></i>' : '<i class="fa fa-moon"></i>';
        }
    }

    // Initialize theme
    const savedTheme = document.cookie.split('; ').find(row => row.startsWith('theme='));
    if (savedTheme) {
        html.dataset.theme = savedTheme.split('=')[1];
    } else {
        const systemTheme = window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
        html.dataset.theme = systemTheme;
    }
    updateThemeIcon();

    // Handle click
    if (themeToggle) {
        themeToggle.addEventListener('click', () => {
            html.dataset.theme = html.dataset.theme === 'light' ? 'dark' : 'light';
            document.cookie = `theme=${html.dataset.theme}; path=/; max-age=${60 * 60 * 24 * 365}`; // 1 year
            updateThemeIcon();
        });
    }

    // ------------------------
    // Mobile Sidebar
    // ------------------------
    const sidebar = document.getElementById('mobile-sidebar');
    const hamburgerBtn = document.getElementById('hamburger-btn');
    const closeSidebarBtn = document.getElementById('close-sidebar');

    if (sidebar && hamburgerBtn && closeSidebarBtn) {
        hamburgerBtn.addEventListener('click', () => sidebar.classList.add('open'));
        closeSidebarBtn.addEventListener('click', () => sidebar.classList.remove('open'));

        // Close sidebar if clicking outside of it
        document.addEventListener('click', (e) => {
            if (!sidebar.contains(e.target) && !hamburgerBtn.contains(e.target)) {
                sidebar.classList.remove('open');
            }
        });
    }

    // ------------------------
    // Mobile Search Toggle
    // ------------------------
    const searchToggle = document.getElementById('search-toggle');
    const searchForm = document.getElementById('search-form');
    const searchInput = searchForm ? searchForm.querySelector('.search-input') : null;

    if (searchToggle && searchForm && searchInput) {
        searchToggle.addEventListener('click', (e) => {
            e.stopPropagation(); // Prevent document click listener from firing immediately
            searchForm.classList.toggle('expanded');
            if (searchForm.classList.contains('expanded')) {
                searchInput.focus();
            }
        });

        // Close search form if clicking outside
        document.addEventListener('click', (e) => {
            if (!searchForm.contains(e.target) && !searchToggle.contains(e.target)) {
                searchForm.classList.remove('expanded');
            }
        });
    }
});