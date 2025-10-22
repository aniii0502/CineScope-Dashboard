/* =========================================
   🎬 CineScope - Movies Page (movies.js)
   Handles filter form + page reloads
   ========================================= */

document.addEventListener("DOMContentLoaded", () => {
    const applyBtn = document.getElementById("apply-filters");

    applyBtn?.addEventListener("click", () => {
        const genre = document.getElementById("genre").value;
        const year = document.getElementById("year").value;
        const sort = document.getElementById("sort").value;

        // Construct query params
        const params = new URLSearchParams();

        if (genre) params.append("genre", genre);
        if (year) params.append("year", year);
        if (sort) params.append("sort", sort);

        // Navigate to the same Movies/Index endpoint with filters
        window.location.href = `/Movies?${params.toString()}`;
    });
});
