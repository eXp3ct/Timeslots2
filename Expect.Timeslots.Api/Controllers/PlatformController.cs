using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;
using Expect.Timeslots.Infrastructure.Common.Queries.AddPlatform;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Expect.Timeslots.Api.Controllers
{
    /// <summary>
    /// Platform controller
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/[controller]")]
    public class PlatformController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Creating platform
        /// </summary>
        /// <param name="dto">Platform info</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Created platform</returns>
        [HttpPost]
        [ProducesResponseType<OperationResult>(201, "application/json")]
        [ProducesResponseType<OperationResult>(400, "application/json")]
        [ProducesResponseType<OperationResult>(500, "application/json")]
        public async Task<IActionResult> CreatePlatform([FromBody] PlatformDto dto, CancellationToken cancellationToken)
        {
            var request = new AddPlatform(dto);

            var result = await _mediator.Send(request, cancellationToken);

            if(result.Code == (int)HttpStatusCode.BadRequest)
                return BadRequest(result);

            return Created("/", result);
        }
    }
}
