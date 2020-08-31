



namespace ExerciseAngular.Infraestructure.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration config)
        {
            return config.GetConnectionString("DefaultConnection");
        }

        
    }


}
