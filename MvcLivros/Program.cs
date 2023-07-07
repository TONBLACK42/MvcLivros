using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcLivros.Data;
using MvcLivros.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcLivrosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcLivrosContext") ?? throw new InvalidOperationException("Connection string 'MvcLivrosContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Propagar o banco de dados de Teste com carga Inicial.
using(var scope = app.Services.CreateScope())
{
    var servises = scope.ServiceProvider;

    SeedData.Initialize(servises);
}

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
