using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPageMovie2.Data;
using RazorPageMovie2.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorPageMovie2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPageMovie2Context") ?? throw new InvalidOperationException("Connection string 'RazorPageMovie2Context' not found.")));

var app = builder.Build();

using (var scope= app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);

}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
    }
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
