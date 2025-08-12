using Microsoft.EntityFrameworkCore;
using SchoolPortal.Application.CQRS.Queries;
using SchoolPortal.Domain.SeedWork;
using SchoolPortal.Infrastructure;
using SchoolPortal.Infrastructure.Repository;
using System.Reflection;
using System.Threading.Tasks;

namespace SchoolPortal.Application;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddSwaggerGen();

        // Inject the generic repository as scoped
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped<DepartmentQuery>();
        builder.Services.AddMediatR(m => m.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        builder.Services.AddDbContext<SchoolContext>(options =>
        {
            options.UseNpgsql(builder.Configuration["ConnectionString"]);
        });

        var app = builder.Build();

        await SeedAsync(app);

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

    public static async Task SeedAsync(WebApplication host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<SchoolContext>();
            await SchoolContextSeed.SeedAsync(context);
        }
    }
}
