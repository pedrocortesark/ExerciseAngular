﻿
namespace ExerciseAngular.Infraestructure.Extensions
{
    using Data;
    using ExerciseAngular.Data.Models;
    using ExerciseAngular.Features.Cats;
    using ExerciseAngular.Features.Identity;
    using ExerciseAngular.Infraestructure.Filters;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using System.Text;

    public static class ServiceCollectionExtensions
    {
        public static AppSettings GetApplicationSettings(this IServiceCollection services, IConfiguration config)
        {
            var appSettingsSectionConfiguration = config.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSectionConfiguration);
            return appSettingsSectionConfiguration.Get<AppSettings>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDbContext<CatstagramDbContext>(options => options
                .UseSqlServer(config.GetDefaultConnectionString()));

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<CatstagramDbContext>();
            
            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AppSettings appSettings)
        {

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);


            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<ICatService, CatService>();

            return services;
        }


        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My Catstagram API", 
                    Version = "v1"
                });
            });

            return services;
        }

        public static IServiceCollection AddApiControllers(this IServiceCollection services)
        {
            services
                .AddControllers(options => options
                    .Filters
                    .Add<ModelOrNotFoundActionFilter>());

            return services;
        }
    }
}
