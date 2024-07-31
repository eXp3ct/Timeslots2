
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

                var result = new OperationResult(false, StatusCodes.Status400BadRequest, errors);

                _logger.LogWarning("Error occured while validating");

                context.Response.StatusCode = result.Code;

                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }
}
