using eTicket.Data;
using eTicket.Data.Cart;
using eTicket.Data.Service;
using eTicket.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnectstring")));
builder.Services.AddScoped<IActorService , ActorService>();
builder.Services.AddScoped<ICinemaService, CinemaService>();
builder.Services.AddScoped<IProducerService, ProducerService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication( options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//AppDbIntalizer.seed(app);
await AppDbIntalizer.seedUserAndRoleAsync(app);
//Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
