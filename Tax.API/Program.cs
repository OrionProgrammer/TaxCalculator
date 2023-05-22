using Tax.API.Business_Rules;
using Tax.API.Middleware;
using Tax.Domain;
using Tax.Repository;
using Tax.Repository.Helpers;


var builder = WebApplication.CreateBuilder(args);

{
    // Add services to the container.
    var services = builder.Services;

    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    //automapper service
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    //database service
    services.AddDbContext<DataContext>();
    services.AddCors();

    //add dependencies
    services.AddTransient<ProgressiveTax>();
    services.AddTransient<FlateRateTax>();
    services.AddTransient<FlatValueTax>();
    services.AddTransient<Func<TaxType.Type, ITaxBase>>(serviceProvider => key =>
    {
        switch (key)
        {
            case TaxType.Type.Progressive:
                return serviceProvider.GetService<ProgressiveTax>();
            case TaxType.Type.Flat_Rate:
                return serviceProvider.GetService<FlateRateTax>();
            case TaxType.Type.Flat_Value:
                return serviceProvider.GetService<FlatValueTax>();
            default:
                return null;
        }
    });
    services.AddScoped<ITaxRepository, TaxRepository>();
    services.AddScoped<IUnitOfWork, UnitOfWork>();
}

{
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // global cors policy
    app.UseCors(x => x
        .SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

    // global error handler
    app.UseMiddleware<ExceptionHandler>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}


// Make the implicit Program class public so test projects can access it
public partial class Program { }