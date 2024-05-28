using CorePlatform.Services.Infrastructure;
using CorePlatform.Services.Infrastructure.Behaviors;
using CorePlatform.Services.UseCases.CommandQueries.Employee.Query;
using FastEndpoints;
using FastEndpoints.Swagger;
using Serilog;
using Serilog.Extensions.Logging;
using System.Reflection;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting Core Platform Services.....");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
var microsoftLogger = new SerilogLoggerFactory(logger)
    .CreateLogger<Program>();

// Configure Web Behavior
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

//Configure fast endpoints
builder.Services.AddFastEndpoints()
                .SwaggerDocument(o =>
                {
                    o.ShortSchemaNames = true;
                });

ConfigureMediatR();

builder.Services.AddInfrastructureServices(builder.Configuration, microsoftLogger);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseDefaultExceptionHandler(); // from FastEndpoints
    app.UseHsts();
}

app.UseFastEndpoints().UseSwaggerGen(); // Includes AddFileServer and static files middleware

app.UseHttpsRedirection();

InitializeAppDbContext(app);

app.Run();


void InitializeAppDbContext(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<ApplicationDBContext>();
        context.Database.EnsureCreated();
        //UnitOfWork.Initialize();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
    }
}

void ConfigureMediatR()
{
    var mediatRAssemblies = new[]
    {
        Assembly.GetAssembly(typeof(EmployeeQuery)) // UseCases
    };
    builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssemblies(mediatRAssemblies!)

    );

    builder.Services.AddMediatR(m =>
    {
        m.RegisterServicesFromAssemblies(mediatRAssemblies!);

        //Order mathers
        m.AddOpenBehavior(typeof(LoggingBehavior<,>));
        m.AddOpenBehavior(typeof(ValidationBehavior<,>));

    });

}
