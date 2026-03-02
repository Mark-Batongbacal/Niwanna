using Microsoft.EntityFrameworkCore;
using Niwanna.Data;



var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

// Add EF Core with SQLite
builder.Services.AddDbContext<IponContext>(options =>
    options.UseSqlite("Data Source=ipon.db"));

var app = builder.Build();


using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<IponContext>();
db.Database.EnsureCreated(); // <-- auto-creates tables if missing

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
