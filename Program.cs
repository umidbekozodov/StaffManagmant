using Microsoft.EntityFrameworkCore;
using StaffManagment.DataAccess.Context;
using StaffManagment.DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddScoped<IStaffRepository, SqlServerStaffRepository>();
builder.Services.AddDbContextPool<AppDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseMvc(builder => builder.MapRoute("default", "{controller=Staff}/{action=Index}/{id?}"));
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.UseAuthorization();

app.Run();
