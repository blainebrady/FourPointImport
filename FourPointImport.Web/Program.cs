using FourPointImport.Data;
using FourPointImport.Web;
using FourPointImport.Services;

var builder = WebApplication.CreateBuilder(args);
using IHost host = Host.CreateDefaultBuilder(args).Build();
var configuration = host.Services.GetRequiredService<IConfiguration>();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApiDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<billingDetailService, billingDetailService>();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true);

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.Run();
