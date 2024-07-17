using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UserPhotoAdd;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure MassTransit
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("RabbitMq"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<RabbitMqSettings>>().Value);

    builder.Services.AddMassTransit(busConfugurator => busConfugurator.UsingRabbitMq((configure, configurator) =>
    {
       
    });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
