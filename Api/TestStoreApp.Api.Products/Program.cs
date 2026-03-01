using Asp.Versioning;
using TestStoreApp.Api.Products.Infrastructure;
using TestStoreApp.Api.Products.Repositories;
using TestStoreApp.Api.Products.Repositories.Implementation;

namespace TestStoreApp.Api.Products
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;
            }).AddApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });

            builder.Services.AddNpgsql<ProductsContext>(builder.Configuration.GetConnectionString("ProductDB"));
            builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
