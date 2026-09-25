using jogador.api.Filters;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>{ new CultureInfo("en"), new CultureInfo("pt-BR")};

    options.DefaultRequestCulture = new RequestCulture("pt-BR");

    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new AcceptLanguageHeaderRequestCultureProvider()
    };
});

builder.Services.AddMvc(options => options.Filters.Add<ExceptionFilter>());

var app = builder.Build();

var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();

app.UseRequestLocalization(localizationOptions.Value);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
