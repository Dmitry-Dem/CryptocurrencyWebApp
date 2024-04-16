using CWA.Application.Services;
using CWA.Domain.API;
using CWA.Domain.Repositories;
using CWA.Domain.Services;
using CWA.Infrastructure.API;
using CWA.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ICryptoAPI, CryptoAPI>();
builder.Services.AddTransient<FallbackCryptoAPI>();
builder.Services.AddTransient<ICryptoRepository, CryptoRepository>();
builder.Services.AddTransient<ICryptoService, CryptoService>();
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
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
