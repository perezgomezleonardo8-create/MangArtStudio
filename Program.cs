using Microsoft.EntityFrameworkCore;
using MangArtStudio.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();

// Registrar el contexto de la base de datos (InventarioContext)
builder.Services.AddDbContext<InventarioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventarioConnection")));

var app = builder.Build();

// Configurar la tubería de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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