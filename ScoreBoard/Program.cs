using Microsoft.EntityFrameworkCore;
using ScoreBoard.Models;
using ScoreBoard.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ScoresDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ScoresConnection"))
    );
builder.Services.AddScoped<IJoueurRepository, BDJoueurRepository>();
builder.Services.AddScoped<IJeuRepository, BDJeuRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

InitBD.Initialiser(app);

app.Run();
