using CRUD_MVC.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();





//UseSqlServer
builder.Services.AddDbContext<PersonDbContext>(options =>
//options.UseNpgsql(
options.UseSqlServer(
builder.Configuration.GetConnectionString("PersonDbContext")
));



//var conn = configuration.GetConnectionString("MySource");
//00builder.Services.AddDbContext<PersonDbContext>(options =>
//options.UseSqlServer());


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
