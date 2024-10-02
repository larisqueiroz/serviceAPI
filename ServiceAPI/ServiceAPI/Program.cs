using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceAPI.Data;
using ServiceAPI.Repositories.Implementations;
using ServiceAPI.Repositories.Interfaces;
using ServiceAPI.Services.Implementations;
using ServiceAPI.Services.Interfaces;
using ServiceAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var mapping = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfiles()); });
IMapper mapper = mapping.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddSingleton<IRabbitMQClientService, RabbitMQClientService>();

builder.Services.AddDbContext<ServiceAPIContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("ServiceAPI")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ServiceAPIContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServiceAPI v1");
        c.RoutePrefix = string.Empty;
    });
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();