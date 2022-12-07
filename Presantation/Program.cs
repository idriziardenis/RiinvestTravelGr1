using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Presantation.FileHelper;
using RiinvestTravel.App.Implementations;
using RiinvestTravel.App.Interfaces;
using RiinvestTravel.Data.Context;
using RiinvestTravel.Data.Identity;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<DBRiinvestTravelContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRolesRepository, RolesRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ISelectListService, SelectListService>();
builder.Services.AddTransient<ISelectListService, SelectListService>();
builder.Services.AddTransient<IFileHelper, FileHelper>();
builder.Services.AddTransient<IThumbnailService, ThumbnailService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var en = new CultureInfo("en-US");
    en.NumberFormat.NumberDecimalSeparator = ".";
    en.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
    en.DateTimeFormat.LongTimePattern = "dd/MM/yyyy";
    en.DateTimeFormat.ShortTimePattern = "HH:mm";
    en.DateTimeFormat.LongTimePattern = "HH:mm";
    var al = new CultureInfo("sq-AL");
    al.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
    al.DateTimeFormat.LongTimePattern = "dd.MM.yyyy";
    al.DateTimeFormat.ShortTimePattern = "HH:mm";
    al.DateTimeFormat.LongTimePattern = "HH:mm";
    al.NumberFormat.NumberDecimalSeparator = ".";

    var supportedCultures = new[]
    {
        en,
        al
    };

    options.DefaultRequestCulture = new RequestCulture(en, en);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => false; // was true
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.Configure<CookieTempDataProviderOptions>(options =>
{
    options.Cookie.IsEssential = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Client/Account/Login";
    options.AccessDeniedPath = "/Client/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true;
});

builder.Services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

builder.Services.AddMvc()
    .AddViewLocalization(
        LanguageViewLocationExpanderFormat.Suffix,
        opts => { opts.ResourcesPath = "Resources"; })
    .AddDataAnnotationsLocalization();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

var supportedCultures = new[] { "en-US", "sq-AL" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);


app.UseRouting();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists=Client}/{controller=Home}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();