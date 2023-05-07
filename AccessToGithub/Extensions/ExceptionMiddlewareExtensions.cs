using AccessToGithub.CustomExceptionMiddleware;
using Entities.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace AccessToGithub.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
