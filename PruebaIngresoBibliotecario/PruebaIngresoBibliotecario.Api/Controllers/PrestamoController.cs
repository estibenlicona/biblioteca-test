using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Application.Loans.Commands;
using PruebaIngresoBibliotecario.Application.Loans.Queries;
using PruebaIngresoBibliotecario.Domain.DTOs.Loans;
using System;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PrestamoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CreateLoanDTO> Create([FromBody] CreateLoanCommand command)
        {
            CreateLoanDTO createLoan = await _mediator.Send(command);
            return createLoan;    
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<FindLoanDTO> Find([FromRoute] Guid id)
        {
            FindLoanDTO findLoan = await _mediator.Send(new FindLoanQuery { Id = id });
            return findLoan;
        }
    }
}
