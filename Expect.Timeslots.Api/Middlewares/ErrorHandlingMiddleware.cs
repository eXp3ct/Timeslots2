
using Expect.Timeslots.Domain.Models;
using FluentValidation;

namespace Expect.Timeslots.Api.Middlewares
{
    /// <summary>
    /// Error handler
    /// </summary>
    /// <param name="logger"></param>
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;

        /// <summary>
        /// Catching error if any
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(ValidationException ex)
            {
                var errors = ex.Errors
                    .Select(e => new
                    {
                        e.ErrorMessage,
                        e.PropertyName,
                        e.AttemptedValue,
                    })
                    .ToList();

                _logger.LogWarning("Object can't pass through validation");

                await ModifyResponse(context, StatusCodes.Status400BadRequest, errors);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Unhanlded error occured");
                await ModifyResponse(context, StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private async Task ModifyResponse(HttpContext context, int statusCode, object? data)
        {
            _logger.LogWarning("API's response was modifed from {statusCode} to {newStatusCode} status code", context.Response.StatusCode, statusCode);

            context.Response.StatusCode = statusCode;

            var result = new OperationResult(statusCode, data);

            await context.Response.WriteAsJsonAsync(result);
        }
    }
}
