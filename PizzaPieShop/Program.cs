using Microsoft.EntityFrameworkCore;
using PizzaPieShop.IRepositories;
using PizzaPieShop.Models;
using PizzaPieShop.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
//builder.Services.AddScoped<IPieRepository, MockPieRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PieShopDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:Default"]);
});

var app = builder.Build();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
   // app.UseHsts();
}

app.MapDefaultControllerRoute();

//app.UseRouting();
//app.MapGet("/", () => "Hello World!");

app.Run();
