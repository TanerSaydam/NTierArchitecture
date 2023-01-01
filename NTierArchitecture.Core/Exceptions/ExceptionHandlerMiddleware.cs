using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Core.Exceptions
{
    public static class ExceptionHandlerMiddleware
    {
        public static IApplicationBuilder UseExceptionHandlerHelper(this IApplicationBuilder app)
        {         
            return app.UseMiddleware<ExceptionHandler>();
        }
    }
}
