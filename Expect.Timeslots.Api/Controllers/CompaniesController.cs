using Expect.Timeslots.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expect.Timeslots.Api.Controllers
{
    /// <summary>
    /// Compnies controller
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/[controller]")]
    public class CompaniesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Create company
        /// </summary>
        /// <remarks>
        /// Example:
        /// 
        ///     POST /companies
        ///     {
        ///         "name" : "Google"
        ///     }
        /// </remarks>
        /// <param name="dto">Company info</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Created company</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDto dto, CancellationToken cancellationToken)
        {
            return Ok(dto);
        }
    }
}
