using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace FourPointImport.Data
{
    public class ApiDbContext : DbContext
    {
        protected IConfiguration _configuration;

        public ApiDbContext()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\appsettings.json").Build();
        }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected virtual IList<Assembly> Assemblies
        {
            get
            {
                return new List<Assembly>() { Assembly.Load("FourPointImport.Data") };
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            foreach (var assembly in Assemblies)
            {
                try
                {
                    var classes = assembly.GetTypes()
                        .Where(type => type.IsClass && type.IsPublic && type.BaseType == typeof(Base) && type.IsPublic && !type.IsAbstract)
                        .ToList();
                    Console.WriteLine(classes.Count.ToString());
                    foreach (var classType in classes)
                    {
                        var onModelCreatingMethod = classType.GetMethods().FirstOrDefault(x => x.Name == "OnModelCreating" && x.IsStatic);
                        if (onModelCreatingMethod != null)
                        {
                            onModelCreatingMethod.Invoke(classType, new object[] { modelBuilder });
                            Console.WriteLine(classType.Name);
                        }
                        if (classType.BaseType == null || classType.BaseType != typeof(Base))
                        {
                            continue;
                        }

                        var baseOnModelCreatingMethod = classType.BaseType.GetMethods().FirstOrDefault(x => x.Name.ToLower() == "onmodelcreating" && x.IsStatic);
                        if (baseOnModelCreatingMethod == null)
                        {
                            continue;
                        }
                        baseOnModelCreatingMethod.Invoke(classType, new object[] { modelBuilder });
                        var baseInModelCratingGenericMethod = baseOnModelCreatingMethod.MakeGenericMethod(new Type[] { classType });
                        if (baseInModelCratingGenericMethod == null)
                        {
                            continue;
                        }
                           
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("*********************Error: " + ex.InnerException);
                }

            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured || _configuration == null)
            {
                _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            }
            //now set the database connection
            if (_configuration["ConnectionStrings:DefaultConnection"] != null)
                builder.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]);
        }
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Base)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("Created").CurrentValue = DateTimeOffset.Now;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("LastUpdated").CurrentValue = DateTimeOffset.Now;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}