using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using web_api_simposium.Attributes;
using web_api_simposium.Data;
using web_api_simposium.Middlewares;
using web_api_simposium.Repositories.BusinessLogic.User;
using web_api_simposium.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => options.InvalidModelStateResponseFactory = ModelStateValidator.ValidModelState);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "WebSitesPolicy", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllers();
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IDapperService, DapperService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT Bearer token **_only_**",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement { { securityScheme, new string[] { } } });


    c.SwaggerDoc("Users", new OpenApiInfo
    {
        Title = "Users",
        Version = "v1",
        Description = "Documento para la administracion de los usuarios",
        Contact = new OpenApiContact
        {
            Name = "Jaime Tenorio",
            Email = "test@test.com",
        },
        License = new OpenApiLicense
        {
            Name = "Use inder license ###"
        }
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c => c.RouteTemplate = "/swagger/{documentname}/swagger.json");

    app.UseSwaggerUI(c =>
    {
        c.ConfigObject = new ConfigObject
        {
            ShowCommonExtensions = true
        };

        c.RoutePrefix = "swagger";
        c.InjectStylesheet("/swagger-ui/custom.css");
        c.InjectJavascript("/swagger-ui/custom.js");
        c.SwaggerEndpoint("Users/swagger.json", "Users");
    });
}
else
{
    app.UseSwagger(c => c.RouteTemplate = "/apiDocumentation/{documentname}/swagger.json");

    app.UseSwaggerUI(c =>
    {
        c.ConfigObject = new ConfigObject
        {
            ShowCommonExtensions = true
        };

        c.RoutePrefix = "apiDocumentation";
        c.InjectStylesheet("/swagger-ui/custom.css");
        c.InjectJavascript("/swagger-ui/custom.js");
        c.SwaggerEndpoint("Users/swagger.json", "Users");
    });
}

app.UseHttpsRedirection();

app.UseCors("WebSitesPolicy");

app.UseAuthorization();

app.UseStaticFiles();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
