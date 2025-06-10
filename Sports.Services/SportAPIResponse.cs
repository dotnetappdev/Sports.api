using Sports.Models;

public class SportAPIResponse
{
    public bool Success { get; set; }
    public object? Data { get; set; }
    public Exception? Ex { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
    public List<ValidationError> ValidationErrors { get; set; } = new();

    public SportAPIResponse() { }
 

    public SportAPIResponse(string message, int statusCode, bool success = false)
    {
        Message = message;
        StatusCode = statusCode;
        Success = success;
    }

  
    public static SportAPIResponse Fail(string message, int statusCode = 400, Exception? ex = null)
    {
        return new SportAPIResponse(message, statusCode, false) { Ex = ex };
    }
}
