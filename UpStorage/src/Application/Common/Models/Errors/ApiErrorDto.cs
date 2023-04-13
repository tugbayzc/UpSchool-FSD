namespace Application.Common.Models.Errors;

public class ApiErrorDto
{
    public string Message { get; set; }
    public List<ErrorDto> Errors { get; set; }

    public ApiErrorDto()
    {
        Errors = new List<ErrorDto>();
    }

    public ApiErrorDto(string message)
    {
        Message = message;
    }

    public ApiErrorDto(string message,List<ErrorDto> errors)
    {
        Message = message;
        Errors = errors;
    }
}