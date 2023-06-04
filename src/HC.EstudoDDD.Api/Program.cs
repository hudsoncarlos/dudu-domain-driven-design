using HC.EstudoDDD.Api.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddApiVersioning(options => {
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(option => {
    option.GroupNameFormat = "'v'VVV";
    option.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "HC.EstudoDDD - OpenAPI 3.1",
        Description = "HC.EstudoDDD - OpenAPI 3.1 (ASP.NET Core 6.0)",
        Contact = new OpenApiContact()
        {
            Name = "Entrar em contato",
            Url = new Uri("https://github.com/hudsoncarlos/dudu-curso-ddd"),
            Email = "hudsonscarlos@outlook.com"
        },
        TermsOfService = new Uri("http://swagger.io/terms/")
    });
    c.CustomSchemaIds(type => type.FullName);
    var caminhoDoXml = Path.Combine(AppContext.BaseDirectory, "HC.EstudoDDD.Api.xml");
    c.IncludeXmlComments(caminhoDoXml);
    // Sets the basePath property in the Swagger document generated
    c.DocumentFilter<BasePathFilter>("/api/v1");

    // Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
    c.OperationFilter<GeneratePathParamsValidationFilter>();
});

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
