using Ecommerce.Domain.DTO_Classes;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Net;
using System.Text.Json;

namespace Ecommerce_API.GlobalExceptionHandler
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next , ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;   

        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;


            var errorResponse = new Exceptionrespoance();

            switch (exception)
            {

                case UnauthorizedAccessException ex:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    errorResponse.message = ex.Message + "You dont have Authorization to access the perticular resource";
                    errorResponse.StackTrace = ex.StackTrace;
                    break;
                case NoNullAllowedException ex:
                    response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                    errorResponse.message = ex.Message;
                    errorResponse.StackTrace = ex.StackTrace;
                    break;
                case KeyNotFoundException ex:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    errorResponse.message = ex.Message;
                    errorResponse.StackTrace = ex.StackTrace;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.message = exception.Message;
                    errorResponse.StackTrace = exception.StackTrace;
                    break;

            }
            _logger.LogError(errorResponse.StackTrace);
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}
