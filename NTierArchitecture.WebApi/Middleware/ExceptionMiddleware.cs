
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace NTierArchitecture.WebApi.Middleware;

public sealed class ExceptionMiddleware : IMiddleware
{
	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	private Task HandleExceptionAsync(HttpContext context, Exception ex)
	{
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = 500;

		return context.Response.WriteAsync(new ErrorResult()
        {
			Message = ex.Message
		}.ToString());
	}
}

public class ErrorResult
{
	public string Message { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);	
    }
}
