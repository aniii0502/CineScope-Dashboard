using CineScope.Config;
using CineScope.Helpers;
using CineScope.Services.Implementations;
using CineScope.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// --- 1. Configure Services (Dependency Injection) ---

// Add services for the MVC pattern (Controllers and Views).
builder.Services.AddControllersWithViews();

// Bind the "ApiKeys" and "AppSettings" sections from appsettings.json to their respective C# classes.
builder.Services.Configure<ApiKeys>(builder.Configuration.GetSection("ApiKeys"));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Register the HttpClientFactory to efficiently manage HttpClient instances.
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

// Register your custom helper class. It's scoped, meaning a new instance is created for each web request.
builder.Services.AddScoped<HttpHelper>();

// Register all your service interfaces with their corresponding implementation classes.
// This allows your controllers to request an 'IMovieService' and get a 'MovieService' instance automatically.
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ISearchService, SearchService>();

// --- 2. Build the Application ---

var app = builder.Build();

// --- 3. Configure the HTTP Request Pipeline (Middleware) ---

// Configure error handling for different environments.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Enable serving static files (like CSS, JavaScript, and images) from the wwwroot folder.
app.UseStaticFiles();

// Enable routing to map incoming requests to the correct controller action.
app.UseRouting();

// (Optional) Add authorization middleware if you add user login features later.
// app.UseAuthorization();

// Define the default controller route. This maps URLs like "/Movies/Details/5" to the correct action.
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

// --- 4. Run the Application ---

app.Run();
