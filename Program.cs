using BanReservas.API.Application.Services;
using BanReservas.API.Domain.Interfaces;
using BanReservas.API.Infrastructure.Providers;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddXmlSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IExchangeService, ExchangeService>();
builder.Services.AddScoped<IApi1ExchangeProvider, Api1ExchangeProvider>();
builder.Services.AddScoped<IApi2ExchangeProvider, Api2ExchangeProvider>();
builder.Services.AddScoped<IApi3ExchangeProvider, Api3ExchangeProvider>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
