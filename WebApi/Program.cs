using WebApi.Services;
using Scalar.AspNetCore;
using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Components ??= new Microsoft.OpenApi.OpenApiComponents();

        document.Components.SecuritySchemes =
            new Dictionary<string, Microsoft.OpenApi.IOpenApiSecurityScheme>
            {
                ["Bearer"] = new Microsoft.OpenApi.OpenApiSecurityScheme
                {
                    Type = Microsoft.OpenApi.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Enter your JWT token"
                }
            };
        

        return Task.CompletedTask;
    });
});
builder.Services.AddControllers();
builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddHealthChecks();
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        // Scalar.AspNetCore provides the Scalar API documentation UI.
        // MapScalarApiReference() exposes that UI as an endpoint in our API.
        //
        // The options object lets us customize how Scalar behaves.
        // Here we tell Scalar which OpenAPI security scheme it should
        // use when the user authenticates through the Scalar interface.
        //
        // "Bearer" must match the name we gave our security scheme in
        // AddOpenApi():
        //
        // ["Bearer"] = new OpenApiSecurityScheme { ... }
        options.AddPreferredSecuritySchemes("Bearer");
    });
}

app.UseHttpsRedirection();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
