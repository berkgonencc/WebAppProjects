using BlogApp.Business.Abstract;
using BlogApp.Business.Concrete;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Web.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyAppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteCon")));
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteCon")));
//User:IdentityUser
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    //password
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    //login
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;
    //user
    options.User.RequireUniqueEmail = true;
}
);
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/account/accessdenied";
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    options.Cookie = new CookieBuilder()
    {
        Name = ".BlogApp.Security.Cookie",
        HttpOnly = true,
    };
});

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IPostService, PostManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
