using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;
using Expect.Timeslots.Infrastructure.Common.Queries.AddPlatform;
using Expect.Timeslots.Infrastructure.Common.Queries.DeletePlatform;
using Expect.Timeslots.Infrastructure.Common.Queries.GetPlatform;
using Expect.Timeslots.Infrastructure.Common.Queries.GetPlatforms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType<OperationResult>(StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status400BadRequest, "application/json")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status201Created, "application/json")]
        public async Task<IActionResult> CreatePlatform([FromBody] PlatformDto dto, CancellationToken cancellationToken)
        {
            var request = new AddPlatformRequest(dto);

            var result = await _mediator.Send(request, cancellationToken);

            if (result.Code == StatusCodes.Status400BadRequest)
                return BadRequest(result);

            return Created("/", result);
        }

        /// <summary>
        /// Get all platforms
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Platforms</returns>
        [HttpGet]
        [ProducesResponseType<OperationResult>(StatusCodes.Status200OK, "application/json")]
        public async Task<IActionResult> GetPlatforms(int page, int pageSize, CancellationToken cancellationToken)
        {
            var request = new GetPlatformsRequest(page, pageSize);

            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get platform by id
        /// </summary>
        /// <param name="id">Id of the platform</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Platform</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status404NotFound, "application/json")]
        public async Task<IActionResult> GetPlatform([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetPlatformRequest(id);

            var result = await _mediator.Send(request, cancellationToken);

            if (result.Code == StatusCodes.Status404NotFound)
                return NotFound(result);

            return Ok(result);
        }

        /// <summary>
        /// Delete platform by id
        /// </summary>
        /// <param name="id">Id of the platform</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Deleted platform</returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status404NotFound, "application/json")]
        public async Task<IActionResult> DeletePlatform([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeletePlatformRequest(id);

            var result = await _mediator.Send(request, cancellationToken);

            if (result.Code == StatusCodes.Status404NotFound)
                return NotFound(result);

            return Ok(result);
        }
    }
}
