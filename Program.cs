using CineScope.Config;
using CineScope.Helpers;
using CineScope.Services.Implementations;
using CineScope.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<ApiKeys>(builder.Configuration.GetSection("ApiKeys"));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<HttpHelper>();

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ISearchService, SearchService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.Urls.Add("http://0.0.0.0:80");

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
