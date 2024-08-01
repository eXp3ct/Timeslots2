using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;
using Expect.Timeslots.Infrastructure.Common.Queries.Companies.AddCompany;
using Expect.Timeslots.Infrastructure.Common.Queries.Companies.DeleteCompany;
using Expect.Timeslots.Infrastructure.Common.Queries.Companies.GetCompanies;
using Expect.Timeslots.Infrastructure.Common.Queries.Companies.GetCompany;
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
        [ProducesResponseType<OperationResult>(StatusCodes.Status400BadRequest, "application/json")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status201Created, "application/json")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDto dto, CancellationToken cancellationToken)
        {
            var request = new AddCompanyRequest(dto);

            var result = await _mediator.Send(request, cancellationToken);

            if (result.Code == StatusCodes.Status400BadRequest)
                return BadRequest(result);

            return Created("/", result);
        }

        /// <summary>
        /// Get companies paged
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Example:
        /// 
        ///     GET /companies?page=1&amp;pageSize=10
        /// </remarks>
        /// <returns>List of companies</returns>
        [HttpGet]
        [ProducesResponseType<OperationResult>(StatusCodes.Status200OK, "application/json")]
        public async Task<IActionResult> GetCompanies(int page, int pageSize, CancellationToken cancellationToken)
        {
            var request = new GetCompaniesRequest(page, pageSize);

            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get company by id
        /// </summary>
        /// <param name="id">Id of the company</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Example:
        ///     
        ///     GET /companies/9894EEFD-177C-4776-B828-556F1CA733C6
        /// </remarks>
        /// <returns>Company</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status404NotFound, "application/json")]
        public async Task<IActionResult> GetPlatform([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetCompanyRequest(id);

            var result = await _mediator.Send(request, cancellationToken);

            if (result.Code == StatusCodes.Status404NotFound)
                return NotFound(result);

            return Ok(result);
        }

        /// <summary>
        /// Delete company by id
        /// </summary>
        /// <param name="id">Id of company</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Example:
        /// 
        ///     DELETE /companies/9894EEFD-177C-4776-B828-556F1CA733C6
        /// </remarks>
        /// <returns>Deleted company</returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType<OperationResult>(StatusCodes.Status404NotFound, "application/json")]
        public async Task<IActionResult> DeleteGate([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteCompanyRequest(id);

            var result = await _mediator.Send(request, cancellationToken);

            if (result.Code == StatusCodes.Status404NotFound)
                return NotFound(result);

            return Ok(result);
        }
    }
}
