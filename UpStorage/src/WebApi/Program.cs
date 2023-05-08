using System.Globalization;
using System.Text;
using Application;
using Application.Common.Interfaces;
using Domain.Settings;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi.Filters;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers(
    opt=>opt.Filters.Add<GlobalExceptionFilter>()
    );
//filtreyi bütün controllerlara vermiş olduk!

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
//Dependency Injection ile!


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    //options.SuppressModelStateInvalidFilter = true;
});

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = $"Input your Bearer token in this format - Bearer token to access this API",
    });
    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
            },
            new List<string>()
        },
    });
});


// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(builder.Configuration,builder.Environment.WebRootPath);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                (builder.Configuration["JwtSettings:SecretKey"]))
        };
    });

//localization files path
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
});

builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    var defaultCulture = new CultureInfo("en-GB");

    List<CultureInfo> cultureInfos = new List<CultureInfo>()
    {
        defaultCulture,
        new CultureInfo("tr-TR")
    };

    opt.SupportedCultures = cultureInfos;
    
    opt.SupportedUICultures = cultureInfos;
    
    opt.DefaultRequestCulture = new RequestCulture(defaultCulture);
    
    opt.ApplyCurrentCultureToResponseHeaders = true;
});

builder.Services.AddSignalR();

builder.Services.AddScoped<IAccountHubService, AccountHubManager>();

builder.Services.AddMemoryCache();

//builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

//Localizations
var requestLocalizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
if (requestLocalizationOptions is not null) app.UseRequestLocalization(requestLocalizationOptions.Value);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();