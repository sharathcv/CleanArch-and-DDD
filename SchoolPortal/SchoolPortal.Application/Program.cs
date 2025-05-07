using SchoolPortal.Application.CQRS.Queries;
using SchoolPortal.Domain.SeedWork;
using SchoolPortal.Infrastructure.Repository;
using System.Reflection;

namespace SchoolPortal.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Inject the generic repository as scoped
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<DepartmentQuery>();
            builder.Services.AddMediatR(m => m.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // Add db context injection here
            // 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            // to get swagger back add below UseSwaggerUI() call
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "School Portal Swagger"));

            //app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
