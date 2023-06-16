using FourPointImport.Data;
using FourPointImport.Web;
using FourPointImport.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApiDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ApiDbContext>();
//set up the ApiDbContext for the Migrate services
builder.Services.AddSingleton<IDesignTimeDbContextFactory<ApiDbContext>, DesignTimeDbContext>();
//register the other services in use
builder.Services.AddScoped<BillingDetailService, BillingDetailService>();
builder.Services.AddSingleton<CoverageMasterService, CoverageMasterService>();
builder.Services.AddSingleton<FormMasterService, FormMasterService>();
builder.Services.AddSingleton<ProductCoverageService, ProductCoverageService>();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.Run();
