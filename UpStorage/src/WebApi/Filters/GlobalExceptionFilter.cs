using System.Text.Json;
using Application.Common.Models.Errors;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

public class GlobalExceptionFilter:IAsyncExceptionFilter
{
    public  Task OnExceptionAsync(ExceptionContext context)
    {
        ApiErrorDto apiErrorDto = new ApiErrorDto();
        
        
        switch (context.Exception)
        {
            case ValidationException:
                
                var validationException = context.Exception as ValidationException;
                var propertyNames = validationException.Errors
                    .Select(x => x.PropertyName)
                    .Distinct();
                foreach (var propertyName in propertyNames)
                {
                    var propertyFailures = validationException.Errors
                        .Where(e => e.PropertyName == propertyName)
                        .Select(x => x.ErrorMessage)
                        .ToList();
                    
                    apiErrorDto.Errors.Add(new ErrorDto(propertyName,propertyFailures));
                    
                }
                
                apiErrorDto.Message = "One or more validation error were occured.";
                context.Result = new BadRequestObjectResult(apiErrorDto);
                
                break;

            default:
                apiErrorDto.Message = "An unexpected error was occured.";
                context.Result = new ObjectResult(apiErrorDto)
                {
                    StatusCode = (int)StatusCodes.Status500InternalServerError
                };
                break;
        }
        
        //context.HttpContext.Response.ContentType = "application/json";

        //var apiErrorDtoJson = JsonSerializer.Serialize(apiErrorDto);
        //return context.HttpContext.Response.WriteAsync(apiErrorDtoJson);

        return Task.CompletedTask;
    }
}