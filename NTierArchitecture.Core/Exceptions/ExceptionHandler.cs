using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NTierArchitecture.Core.Exceptions
{
    public class ExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception e)
			{
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				context.Response.ContentType= "application/json";

				ErrorResult errorResult = new()
				{
					StatusCode = (int)HttpStatusCode.InternalServerError,
					Message = e.Message,
				};

				var json = JsonSerializer.Serialize(errorResult);
				await context.Response.WriteAsync(json);				
			}
        }
    }
}
