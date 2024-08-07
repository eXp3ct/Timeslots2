using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Infrastructure.Common.Queries.Users.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Expect.Timeslots.Api.Controllers
{
    /// <summary>
    /// Users controller
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/[controller]")]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Get api key 
        /// </summary>
        /// <param name="login">Login and password</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetApiKey([FromBody] LoginDto login, CancellationToken cancellationToken)
        {
            var request = new LoginRequest(login);

            var result = await _mediator.Send(request, cancellationToken);

            if (result.Code == StatusCodes.Status400BadRequest)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
