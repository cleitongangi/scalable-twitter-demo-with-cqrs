using TwitterDemo.API.Configurations.AutoMapper;
using TwitterDemo.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapperSetup();

// Register dependencies for all layers (Domain, Data, etc)
builder.Services
    .AddDependencyInjectionForAllLayers(
        writeDbConnectionString: builder.Configuration.GetConnectionString("WriteDbConnectionString") ?? throw new NullReferenceException("[WriteDbConnectionString] not defined in appsettings.json")
    );

var app = builder.Build();

// Apply EF migrations in DB
MigrationManager.ApplyMigration(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
