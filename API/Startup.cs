using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using S0WISRXX.PurchaseOrder.Domain.BusinessObjects;
using S0WISRXX.PurchaseOrder.Domain.Interfaces;
using S0WISRXX.PurchaseOrder.Repository.Interfaces;
using S0WISRXX.PurchaseOrder.Repository.Repositories;
using S0WISRXX.PurchaseOrder.Repository.Repositories.Context;



namespace WISR_PurchaseOrder_API
{
    public class Startup
    {
        readonly string SpecificOrigins = "_specificOrigins";
        public IConfiguration _config
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            // Enable custom token validation
            string configSectionName = "AzureAd";
            services.AddEndpointsApiExplorer();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApi(_config, configSectionName);
            services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            // Add services to the container.
            services.AddControllers();
            services.AddSingleton(Log.Logger);

            // Register the DbContext with the dependency injection container
            services.AddDbContext<PurchaseOrderContext>(options =>
                options.UseSqlServer(_config.GetConnectionString("PurchaseOrderDatabase")));


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WISR_PurchaseOrder_API", Version = "v1" });
            });




            // Register the business objects and repositories
            // Repositories
            services.AddScoped<IDetailRepository, DetailRepository>();
            services.AddScoped<IDetailRepository, DetailRepository>();
            services.AddScoped<IDetailRepository, DetailRepository>();
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();


            services.AddScoped<IPurchaseOrderBO, PurchaseOrderBO>();
            services.AddScoped<IDetailBO, DetailBO>();
            services.AddScoped<IMessageBO, MessageBO>();
            services.AddScoped<IMessageDetailBO, MessageDetailBO>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.


            app.UseHttpsRedirection();

            app.UseAuthorization();


            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            if (!env.IsProduction())
            {
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WISR Purchasing API v1");
                });
            }

            app.UseCors(SpecificOrigins);

            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                    context.Context.Response.Headers.Add("Expires", "-1");
                }
            });
            //To be implemented

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }

    public static class StatupExtensionMethods
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                                    new OpenApiInfo
                                    {
                                        Title = "Reference Architecture - WISR Purchasing API",
                                        Version = "v1",
                                        Description = "The WISR Purchasing microservice HTTP API."
                                    });

                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
            });
            return services;
        }
    }
}
