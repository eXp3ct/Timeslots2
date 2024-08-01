using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;
using Expect.Timeslots.Infrastructure.Common.Queries.Platforms.AddPlatform;
using Expect.Timeslots.Infrastructure.Common.Queries.Platforms.DeletePlatform;
using Expect.Timeslots.Infrastructure.Common.Queries.Platforms.GetPlatform;
using Expect.Timeslots.Infrastructure.Common.Queries.Platforms.GetPlatforms;
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
    public class PlatformsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Creating platform
        /// </summary>
        /// <remarks>
        /// Example:
        /// 
        ///     POST /platforms
        ///     {
        ///         "name": "Platform name"
        ///     }
        /// </remarks>
        /// <param name="dto">Platform info</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Created platform</returns>
        [HttpPost]
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
        /// Get platforms paged
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Example:
        ///     
        ///     GET /platforms?page=1&amp;pageSize=10
        /// </remarks>
        /// <returns>List of platforms</returns>
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
        /// <remarks>
        /// Example:
        ///     
        ///     GET /platforms/9894EEFD-177C-4776-B828-556F1CA733C6
        /// </remarks>
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
        /// <remarks>
        /// Example:
        /// 
        ///     DELETE /platforms/9894EEFD-177C-4776-B828-556F1CA733C6
        /// </remarks>
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
