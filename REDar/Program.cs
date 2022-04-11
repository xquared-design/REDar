using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using REDar.Data;
using REDar.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using REDar.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<REDarDataContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("REDarDataContext")));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("REDarContext");
builder.Services.AddDbContext<REDarContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<REDarUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; options.Password.RequiredLength = 6; options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false; options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<REDarContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
