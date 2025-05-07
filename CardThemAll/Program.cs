using CardThemAll.Data; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add EF Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Web API controllers
builder.Services.AddControllers();

var app = builder.Build();

// Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Configure middleware
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();