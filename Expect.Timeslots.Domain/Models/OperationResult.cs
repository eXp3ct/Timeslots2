using Microsoft.AspNetCore.Http;

namespace Expect.Timeslots.Domain.Models
{
    public class OperationResult(int code, object? data)
    {
        public bool Success
        {
            get
            {
                return Code >= StatusCodes.Status200OK && Code < StatusCodes.Status400BadRequest;
            }
        }

        public int Code { get; } = code;
        public object? Data { get; } = data;
    }
}
