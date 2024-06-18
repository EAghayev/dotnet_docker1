using Microsoft.EntityFrameworkCore;
using miniapp1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    if (builder.Environment.IsDevelopment())
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    }
    else
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("Server"));
    }
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
    await dbContext.Database.EnsureCreatedAsync();
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/products", (AppDbContext context) => context.Products.ToList());


app.Run();
