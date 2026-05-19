using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using ItransitionProjectMVC.Data;
using ItransitionProjectMVC.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(cfg => { }, typeof(Program));
builder.Services.AddSwaggerGen();
Env.Load();

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
});
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    
}).AddEntityFrameworkStores<AppDBContext>();

builder.Services.AddAuthentication().AddJwtBearer();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();