using HC.EstudoDDD.Api.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner.

builder.Services.AddControllers();
// Saiba mais sobre como configurar o Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle

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
        Description = "API HC.EstudoDDD - OpenAPI 3.1 (ASP.NET Core 6.0)",
        Contact = new OpenApiContact()
        {
            Name = "Hudson Carlos",
            Url = new Uri("https://github.com/hudsoncarlos/dudu-curso-ddd"),
            Email = "hudsonscarlos@outlook.com"
        },
        TermsOfService = new Uri("http://swagger.io/terms/")
    });
    c.CustomSchemaIds(type => type.FullName);
    var caminhoDoXml = Path.Combine(AppContext.BaseDirectory, "HC.EstudoDDD.Api.xml");
    c.IncludeXmlComments(caminhoDoXml);
    // Sets the basePath property in the Swagger document generated
    //c.DocumentFilter<BasePathFilter>("/HC.EstudoDDD");

    // Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
    c.OperationFilter<GeneratePathParamsValidationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API HC.EstudoDDD"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
