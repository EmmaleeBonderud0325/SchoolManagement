using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolManagement.Data.Data;
using SchoolManagement.Master.Data.Data;
using SchoolManagement.WebService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddCustomeDbContext(Configuration);
            services.EnableJWTAuthentication(Configuration);
            services.AddSwagger();
            services.EnableCors(Configuration);
            services.EnableMultiPartBody(Configuration);
            services.AddControllers();

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new ApplicationModule());

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //IdentityHelper.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

            //app.UseStaticFiles()

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolManagement.WebService v1"));
        }
    }

    public static class CustomeExtensionMethod
    {
        public static IServiceCollection AddCustomeDbContext(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddEntityFrameworkSqlServer().AddDbContext<MasterDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                .UseSqlServer(configuration["MasterDbConnectionString"],
                              sqlServerOptionsAction: sqlOptions =>
                              {
                                          sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                              });
            });

            service.AddEntityFrameworkSqlServer().AddDbContext<SchoolManagementContext>(options =>
            {
                options.UseLazyLoadingProxies()
                .UseSqlServer(configuration["SchoolDbConnectionString"],
                              sqlServerOptionsAction: sqlOptions =>
                              {
                                  sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                              });
            });

            return service;
        }

        public static IServiceCollection EnableJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var context = services.BuildServiceProvider()
                 .GetService<MasterDbContext>();

            var schools = context.Schools.Where(t => t.IsActive == true).ToList();

            services.AddAuthentication
                (cfg =>
                {
                    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,

                   ValidIssuer = configuration["Tokens:Issuer"],
                   ValidAudiences = new List<string>
                   {
                         "mobileapp","webapp"
                   },

                   IssuerSigningKeyResolver = (string token, SecurityToken securityToken, string kid, TokenValidationParameters validationParameters) =>
                   {
                       List<SecurityKey> keys = new List<SecurityKey>();

                       var school = schools.FirstOrDefault(t => t.APIKey.ToString().ToUpper() == kid.ToUpper());
                       if (school != null)
                       {
                           keys.Add(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(school.SecretKey.ToString())));
                       }


                       return keys;
                   }


               };
           });



            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "School Management. - Web API",
                    Version = "v1",
                    Description = "The web service for Solis Tech(Pvt)Ltd. School Management System",
                    TermsOfService = new Uri("https://example.com/terms")
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    //BearerFormat = "JWT",
                    //Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                    }
          });
            });

            return services;

        }

        public static IServiceCollection EnableCors(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedOrigins = new List<string>();
            var allowOrigins = configuration["AllowedOrigins"].Split(",");

            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy",
                          builder => builder.WithOrigins(allowOrigins)
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection EnableMultiPartBody(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = long.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
                o.ValueCountLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddMvc(options =>
            {
                options.MaxModelBindingCollectionSize = int.MaxValue;
            });

            return services;
        }

    }
}
