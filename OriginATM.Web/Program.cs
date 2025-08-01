using Microsoft.EntityFrameworkCore;
using OriginATM.Infraestructura;
using OriginATM.Repository.Implementacion;
using OriginATM.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITarjetaRepository, TarjetaRepository>();
builder.Services.AddScoped<IOperacionRepository, OperacionRepository>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();

    var path = Path.Combine(AppContext.BaseDirectory, "Scripts", "data-seed.sql");
    if (File.Exists(path))
    {
        var conn = db.Database.GetDbConnection();
        conn.Open();

        using var cmd = conn.CreateCommand();
        cmd.CommandText = File.ReadAllText(path);
        cmd.ExecuteNonQuery();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
