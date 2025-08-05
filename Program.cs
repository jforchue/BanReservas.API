using BanReservas.API.Application.Services;
using BanReservas.API.Domain;
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

builder.Services.AddScoped<IExternalService, Api1ExchangeService>();
builder.Services.AddScoped<IExternalService, Api2ExchangeService>();
builder.Services.AddScoped<IExternalService, Api3ExchangeService>();
builder.Services.AddScoped<RateService>();

builder.Services.AddHttpClient<IExternalService, Api1ExchangeService>();
builder.Services.AddHttpClient<IExternalService, Api2ExchangeService>();
builder.Services.AddHttpClient<IExternalService, Api3ExchangeService>();

builder.Services.Configure<ExchangeApiSetting>(builder.Configuration.GetSection("ExchangeApis"));

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
