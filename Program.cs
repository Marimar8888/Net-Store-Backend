using net_store_backend.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using net_store_backend.Application.Services;
using net_store_backend.Domain.Persistence;
using net_store_backend.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddAutoMapper(typeof(CategoryMapperProfile));
builder.Services.AddAutoMapper(typeof(ItemMapperProfile));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<StoreContext>(options =>
        options.UseInMemoryDatabase(connectionString)
        );
}

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
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
