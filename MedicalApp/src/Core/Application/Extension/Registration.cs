

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extension
{
    public static  class Registration
    {
        public static void AddApplicationRegistiration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
        }
    }
}
