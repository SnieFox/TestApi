using Microsoft.Extensions.DependencyInjection;
using GeneratorProject.DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using GeneratorProject.BLL.Interfaces;
using GeneratorProject.BLL.Services;

namespace GeneratorProject.BLL.Extensions
{
    public static class BLLServiceCollectionsExtensions
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IGeneratorService, GeneratorService>();

            return services;
        }
    }
}
