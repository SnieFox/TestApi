using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GeneratorProject.DAL.DatabaseContext;
using GeneratorProject.DAL.Interfaces;
using GeneratorProject.DAL.Entities;
using GeneratorProject.DAL.Repository;

namespace GeneratorProject.DAL.Extensions
{
    public static class DbServiceCollectionsExtensions
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services, string connectionString)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string must be not null or empty", nameof(connectionString));
            }

            services.AddDbContext<GeneratorProjectContext>(db =>
                db.UseNpgsql(connectionString,
                    b => b.MigrationsAssembly("GeneratorProject.Api")));

            services.AddScoped<IRepository<Generator>, GeneratorDetailRepository>();

            return services;
        }
    }
}
