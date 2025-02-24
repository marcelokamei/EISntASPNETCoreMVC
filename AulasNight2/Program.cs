using AulasNight2.Data;
using AulasNight2.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BancoContexto>(options => options.UseMySQL("Server=127.0.0.1;DataBase=GestaoProdutos;Uid=root;Pwd=kameiSQL"));
builder.Services.AddScoped<IRepositorioProdutos, RepositorioProdutos>();
builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
builder.Services.AddScoped<IRepositorioFornecedor, RepositorioFornecedor>();

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
    pattern: "{controller=GestaoProdutos}/{action=Index}/{id?}");

app.Run();
