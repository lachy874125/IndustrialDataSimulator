using IndustrialDataSimulator.Interfaces;
using IndustrialDataSimulator.Services;
using WebAPI.Interfaces;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services
builder.Services.AddSingleton<IDataGenerator, DataGenerator>();
builder.Services.AddSingleton<DataGeneratorService>();
builder.Services.AddSingleton<IDataGeneratorService>(sp => sp.GetRequiredService<DataGeneratorService>());
builder.Services.AddHostedService(sp => sp.GetRequiredService<DataGeneratorService>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
