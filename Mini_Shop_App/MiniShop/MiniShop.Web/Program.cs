using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MiniShop.Business.Abstract;
using MiniShop.Business.Concrete;
using MiniShop.Data.Abstract;
using MiniShop.Data.Concrete.EfCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyAppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteCon")));
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

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "EditProduct",
    pattern: "admin/detailsEdit/{id}",
    defaults: new { controller = "Admin", action = "ProductEdit" }
);
app.MapControllerRoute(
    name:"productsByCategory",
    defaults: new {controller="Home", action="ProductList"},
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
