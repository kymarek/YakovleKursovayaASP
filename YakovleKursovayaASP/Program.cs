using Microsoft.EntityFrameworkCore;
using YakovleKursovayaASP.Models;
using YakovleKursovayaASP.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KursachAspContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ArtisticBookService>();
builder.Services.AddScoped<StudingBookService>();
builder.Services.AddScoped<BoardGameService>();
builder.Services.AddScoped<ProductService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();// добавляем IDistributedMemoryCache
builder.Services.AddSession();  // добавляем сервисы сессии

var app = builder.Build();


app.UseSession();   // добавляем middleware для работы с сессиями

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
