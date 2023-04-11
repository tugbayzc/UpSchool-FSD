using System.Text;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt=>opt.Filters.Add<ValidationFilter>());
//filtreyi bütün controllerlara vermiş olduk!

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    //options.SuppressModelStateInvalidFilter = true;
});

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(builder.Configuration);

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