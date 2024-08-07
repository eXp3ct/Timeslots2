using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;
using Expect.Timeslots.Infrastructure.Common.Queries.Gates.AddGate;
using Expect.Timeslots.Infrastructure.Common.Queries.Gates.DeleteGate;
using Expect.Timeslots.Infrastructure.Common.Queries.Gates.GetGate;
using Expect.Timeslots.Infrastructure.Common.Queries.Gates.GetGates;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Expect.Timeslots.Api.Controllers
{
    /// <summary>
    /// Gates controller
    /// </summary>
    /// <param name="mediator"></param>
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/[controller]")]
    public class GatesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Create gate 
        /// </summary>
        /// <param name="dto">Gate info</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Example:
        /// 
        ///     POST /gates
        ///     {
        ///         "number": 10,
        ///         "platformId": 9894EEFD-177C-4776-B828-556F1CA733C6
        ///     }
        /// </remarks>
        /// <returns>Created gate</returns>
        [HttpPost]
        [ProducesResponseType<OperationResult>(StatusCodes.Status400BadRequest, "application/json")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status201Created, "application/json")]
        public async Task<IActionResult> CreateGate([FromBody] GateDto dto, CancellationToken cancellationToken)
        {
            var request = new AddGateRequest(dto);

            var result = await _mediator.Send(request, cancellationToken);

            if (result.Code == StatusCodes.Status400BadRequest)
                return BadRequest(result);

            return Created("/", result);
        }

        /// <summary>
        /// Get gates paged
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Example:
        /// 
        ///     GET /gates?page=1&amp;pageSize=10
        /// </remarks>
        /// <returns>List of gates</returns>
        [HttpGet]
        [ProducesResponseType<OperationResult>(StatusCodes.Status200OK, "application/json")]
        public async Task<IActionResult> GetGates(int page, int pageSize, CancellationToken cancellationToken)
        {
            var request = new GetGatesRequest(page, pageSize);

            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get gate by id
        /// </summary>
        /// <param name="id">Id of gate</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Example:
        /// 
        ///     GET /gates/9894EEFD-177C-4776-B828-556F1CA733C6
        /// </remarks>
        /// <returns>Gate</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status404NotFound, "application/json")]
        public async Task<IActionResult> GetGate([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetGateRequest(id);

            var result = await _mediator.Send(request, cancellationToken);

            if (result.Code == StatusCodes.Status404NotFound)
                return NotFound(result);

            return Ok(result);
        }

        /// <summary>
        /// Delete gate by id
        /// </summary>
        /// <param name="id">Id of gate</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Example:
        /// 
        ///     DELETE /gates/9894EEFD-177C-4776-B828-556F1CA733C6
        /// </remarks>
        /// <returns>Deleted gate</returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status404NotFound, "application/json")]
        public async Task<IActionResult> DeleteGate([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteGateRequest(id);

            var result = await _mediator.Send(request, cancellationToken);

            if (result.Code == StatusCodes.Status404NotFound)
                return NotFound(result);

            return Ok(result);
        }
    }
}
