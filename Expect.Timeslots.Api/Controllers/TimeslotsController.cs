using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;
using Expect.Timeslots.Infrastructure.Common.Queries.Timeslots.GetTimeslots;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expect.Timeslots.Api.Controllers
{
    /// <summary>
    /// Timeslots controller
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/[controller]")]
    public class TimeslotsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Get free timeslots
        /// </summary>
        /// <param name="dto">Search info</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Example:
        /// 
        ///     POST /timeslots
        ///     {
        ///         "pallets": 10,
        ///         "date": 2024-01-01,
        ///         "taskType": 1
        ///     }
        /// </remarks>
        /// <returns>Free timeslots</returns>
        [HttpPost]
        [ProducesResponseType<OperationResult>(StatusCodes.Status200OK, "application/json")]
        public async Task<IActionResult> GetTimeslots([FromBody] TimeslotsDto dto, CancellationToken cancellationToken)
        {
            var request = new GetTimeslotsRequest(dto);

            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }
    }
}
