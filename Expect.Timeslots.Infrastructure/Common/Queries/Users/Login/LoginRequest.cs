using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Users.Login
{
    public class LoginRequest : IRequest<OperationResult>
    {
        public LoginDto Login { get; }

        public LoginRequest(LoginDto login)
        {
            Login = login;
        }
    }
}
