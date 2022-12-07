using BusReservation.Business.Abstract;
using BusReservation.Business.Concrete;
using BusReservation.Data.Abstract;
using BusReservation.Data.Concrete;
using BusReservation.Entity;
using BusReservation.Web.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyAppContext = BusReservation.Data.Concrete.MyAppContext;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteCon")));

builder.Services.AddDbContext<MyAppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteCon")));

//User:IdentityUser
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    //Password
    options.Password.RequireDigit= true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric= true;
    options.Password.RequiredLength = 6;
    //Login
    options.Lockout.MaxFailedAccessAttempts= 5;
    options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers= true;
    //User
    options.User.RequireUniqueEmail= true;
    //SignIn
    //options.SignIn.RequireConfirmedEmail= true; //API
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/account/accessdenied";
    options.LoginPath = "/account/login";
    options.LogoutPath= "/account/logout";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    options.Cookie = new CookieBuilder()
    {
        Name = ".BusReservation.Security.Cookie",
        HttpOnly= true,
    };
});


builder.Services.AddScoped<IBusRepository, BusRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();


builder.Services.AddScoped<IBusService, BusManager>();
builder.Services.AddScoped<ICityService, CityManager>();
builder.Services.AddScoped<ITicketService, TicketManager>();
builder.Services.AddScoped<IPassengerService, PassengerManager>();
builder.Services.AddScoped<ITripService, TripManager>();


builder.Services.AddControllersWithViews();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "search",
    defaults: new { controller = "Home", action = "Search" },
    pattern: "search"
    );
app.MapControllerRoute(
    name: "purchase",
    defaults: new { controller = "Home", action = "Purchase" },
    pattern: "ticket/purchase/{id?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
