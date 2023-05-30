using net_store_backend.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using net_store_backend.Application.Services;
using net_store_backend.Domain.Persistence;
using net_store_backend.Application.Mappings;
using Microsoft.AspNetCore.Diagnostics;
using net_store_backend.Infraestructure.Specs;
using net_store_backend.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped(typeof(ISpecificationParser<>), typeof(SpecificationParser<>));
builder.Services.AddScoped<IImageVerifier, ImageVerifier>();
builder.Services.AddScoped<IStoreUnitOfWork, StoreUnitOfWork>();
builder.Services.AddAutoMapper(typeof(CategoryMapperProfile));
builder.Services.AddAutoMapper(typeof(ItemMapperProfile));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddLogging();
//Agregar la configuración para las URLs en minúsculas
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<StoreContext>(options =>
        options
            .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .UseSqlServer(connectionString)
        );
}

var app = builder.Build();

ConfigureExceptionHandler(app);

if (builder.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    DevelopmentDataLoader dataLoader = new(context);
    dataLoader.LoadData();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureExceptionHandler(WebApplication app)
{
    app.UseExceptionHandler(errorApp =>
    { 
        errorApp.Run(async context =>
        {
            IExceptionHandlerPathFeature? exceptionHandlerPathFeature =
             context.Features.Get<IExceptionHandlerPathFeature>();
            var logger = app.Services.GetRequiredService<ILogger<Program>>();

            if(exceptionHandlerPathFeature?.Error != null)
            {
                logger.LogError(exceptionHandlerPathFeature.Error, "An unhandler ocurred while processing the request.");
            }
            else
            {
                logger.LogError("An unhandler ocurred while processing the request.");
            }
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An unhandler ocurred while processing the request.");

        });
    });
}
