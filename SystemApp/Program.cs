using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SystemApp.Models;

var builder = WebApplication.CreateBuilder(args);
/* User Identity Authentication */
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(config =>
    {
        config.LoginPath = "/Auth/login";
    });
builder.Services.AddDbContext<SystemdbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SystemAppContext") ?? throw new InvalidOperationException("Connection string 'aspdotnetcoreMVCContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

/* User Identity Authentication */
app.UseAuthentication(); //1st
app.UseAuthorization(); //2nd
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ClassesTbls}/{action=Index}/{id?}");

app.Run();
