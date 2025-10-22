namespace CineScope.Config;

/// <summary>
/// Centralizes the application's route configuration.
/// This class can be used in Program.cs to set up endpoint routing.
/// </summary>
public static class RoutesConfig
{
    public static void RegisterRoutes(IEndpointRouteBuilder endpoints)
    {
        // This is the default MVC route pattern.
        // It maps URLs like "/Movies/Details/5" to the Details action
        // in the MoviesController, passing 5 as the id.
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    }
}
