using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace FourPointImport.Data
{
    public class ApiDbContext:DbContext
    {
        protected IConfiguration _configuration;

        public ApiDbContext()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "@\appsettings.json").Build();
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
                var classes = assembly.GetTypes().Where(s => s.GetInterfaces().Any(_interface => _interface.Equals(typeof(IImport))
                    && s.IsClass && s.IsAbstract && s.IsPublic));

                foreach (var _class in classes)
                {
                    try
                    {
                        var onModelCreatingMethod = _class.GetMethods().FirstOrDefault(x => x.Name == "OnModelCreating" && x.IsStatic);

                        if (onModelCreatingMethod != null)
                            onModelCreatingMethod.Invoke(_class, new object[] { modelBuilder });
                        if (_class.BaseType != null || _class.BaseType != typeof(IImport))
                            continue;

                        var baseOnModelCreatingMethod = _class.BaseType.GetMethods().FirstOrDefault(x => x.Name == "onModelCreating" && x.IsStatic);

                        if (baseOnModelCreatingMethod == null)
                            continue;
                        
                        var baseInModelCreatingGenericMethod = baseOnModelCreatingMethod.MakeGenericMethod(new Type[] { _class });

                        if (baseInModelCreatingGenericMethod == null)
                            continue;

                    }
                    catch (Exception ex)
                    {
                        //todo:create error handler
                    }
                }
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
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
                if (entry.Entity is IImport)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("Created").CurrentValue = DateTimeOffset.Now;
                    }
                    if(entry.State == EntityState.Modified)
                    {
                        entry.Property("LastUpdated").CurrentValue = DateTimeOffset.Now;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}