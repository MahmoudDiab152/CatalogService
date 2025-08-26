
using Catalog.Application.Interfaces;
using Catalog.Infrastructure.ExternalServices;
using Microsoft.AspNetCore.Builder;

namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient();
            builder.Services.AddControllers();
            builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
            });
            builder.Services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Catalog API",
                    Version = "v1",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Mahmoud Diab",
                        Email = "mahmouddiab152@gmail.com",
                        Url = new Uri("https://github.com/MahmoudDiab152")

                    }
                });
            });
            // Register My Services
            builder.Services.AddHttpClient<IExternalProductService, ExternalProductService>(client =>
            {
                client.BaseAddress = new Uri("https://fakestoreapi.com/"); // External API Base URL
            });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
