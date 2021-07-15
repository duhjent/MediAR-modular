using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MediAR.Core.Contracts.Dtos;
using MediAR.Core.Contracts.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

[assembly:InternalsVisibleTo("MediAR.MainApi")]
namespace MediAR.Core.Infrastructure.Middleware
{
    internal class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly ConcurrentDictionary<Type, string> _codes = new();
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var statusCode = 500;
                var message = "There was an error.";

                _logger.LogError(exception, exception.Message);
                if (exception is CustomException customException)
                {
                    statusCode = 400;
                    message = customException.Message;
                }

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(_environment.IsDevelopment()
                    ? new BaseErrorResponse(message)
                    : new BaseErrorDetailsResponse(message, exception.StackTrace, exception.GetType().ToString()));
            }
        }
    }
}