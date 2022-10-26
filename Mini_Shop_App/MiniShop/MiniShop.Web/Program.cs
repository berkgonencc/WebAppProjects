using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniShop.Business.Abstract;
using MiniShop.Business.Concrete;
using MiniShop.Data.Abstract;
using MiniShop.Data.Concrete.EfCore;
using MiniShop.Web.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteCon")));
builder.Services.AddDbContext<MyAppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteCon")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    //Password Settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;

    //Login Settings
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;

    //User Settings
    options.User.RequireUniqueEmail = true;

    //SignIn Settings
    //options.SignIn.RequireConfirmedEmail = true;

});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10); //Cookie lifetime
    options.Cookie = new CookieBuilder()
    {
        Name =".MiniShop.Security.Cookie",
        HttpOnly = true
    };
});


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
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
    name: "DeleteProduct",
    pattern: "admin/deleteProduct/{id}",
    defaults: new { controller = "Admin", action = "ProductDelete" }
);
app.MapControllerRoute(
    name: "EditProduct",
    pattern: "admin/detailsEdit/{id}",
    defaults: new { controller = "Admin", action = "ProductEdit" }
);
app.MapControllerRoute(
    name: "productsByCategory",
    defaults: new { controller = "Home", action = "ProductList" },
    pattern: "products/categories/{category?}"
    );
app.MapControllerRoute(
    name: "details",
    pattern: "product/{url}",
    defaults: new { controller = "Home", action = "Details" }
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
