using Microsoft.EntityFrameworkCore;
using StudentMVCApp.Models;
using StudentClassLibrary;
using StudentMVCApp;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<StudentDb>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("StudentMVCContext")));


// Set up SQLite Database
var connectionString = builder.Configuration.GetConnectionString("StudentMVCContext")
    ?? "Data Source=C:\\Users\\Roisi\\OneDrive - Atlantic TU\\5sem\\richAppDev\\week7\\Lab6\\StudentMVCApp\\studentsMVC.db";

builder.Services.AddDbContext<StudentDb>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
seedData.Initialize(services);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
