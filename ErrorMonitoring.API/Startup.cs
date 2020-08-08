using AutoMapper;
using ErrorMonitoring.API.Filters;
using ErrorMonitoring.API.StartupConfig;
using ErrorMonitoring.Dominio.Interfaces;
using ErrorMonitoring.Dominio.Services;
using ErrorMonitoring.Infra.Data.Contexts;
using ErrorMonitoring.Infra.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace ErrorMonitoring.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ErrorResponseFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddDbContext<ApiContext>();
            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IEventsRepository, EventsRepository>();
            services.AddScoped<IProjectsService, ProjectsService>();
            services.AddScoped<IProjectsRepository, ProjectsRepository>();

            services.AddScoped<ILogsService, LogsService>();
            services.AddScoped<ILogsRepository, LogsRepository>();
            services.AddScoped<IEnvironmentsService, EnvironmentsService>();
            services.AddScoped<IEnvironmentsRepository, EnvironmentsRepository>();
            services.AddScoped<IProjectsEnvironmentsService, ProjectsEnvironmentsService>();
            services.AddScoped<IProjectsEnvironmentsRepository, ProjectsEnvironmentsRepository>();

            services.AddAutoMapper(typeof(Startup));
            
            // config Identity por um método de extensão de IServiceCollection
            services.AddIdentityConfiguration(Configuration);

            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
            });
            services.AddApiVersioning(p =>
            {
                p.DefaultApiVersion = new ApiVersion(1, 0);
                p.ReportApiVersions = true;
                p.AssumeDefaultVersionWhenUnspecified = true;
            });

            // config desab validação de Model Sate automatica
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });

            //config swagger
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOption>();

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Insira o token JWT dessa maneira: Bearer {seu token}",

                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "apiKey",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "v1");
            });

            app.UseHttpsRedirection();
            
            app.UseRouting();


            //Autorização Bearer
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
