namespace Expect.Timeslots.Domain.Models
{
    public class OperationResult(bool success, int code, object? data)
    {
        public bool Success { get; } = success;
        public int Code { get; } = code;
        public object? Data { get; } = data;
    }
}
