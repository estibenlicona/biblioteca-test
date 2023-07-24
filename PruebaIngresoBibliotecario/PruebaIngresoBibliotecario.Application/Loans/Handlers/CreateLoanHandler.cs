using AutoMapper;
using MediatR;
using PruebaIngresoBibliotecario.Application.Loans.Commands;
using PruebaIngresoBibliotecario.Domain.DomainServices.Loans;
using PruebaIngresoBibliotecario.Domain.DTOs.Loans;
using PruebaIngresoBibliotecario.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Application.Loans.Handlers
{
    internal class CreateLoanHandler : IRequestHandler<CreateLoanCommand, CreateLoanDTO>
    {
        private readonly ILoanService _loanService;
        private readonly IMapper _mapper;
        public CreateLoanHandler(ILoanService loanService, IMapper mapper)
        {
            _loanService = loanService;
            _mapper = mapper;
        }
        public async Task<CreateLoanDTO> Handle(CreateLoanCommand command, CancellationToken cancellationToken)
        {
            Loan loan = _mapper.Map<Loan>(command);
            loan = await _loanService.AddAsync(loan);
            CreateLoanDTO response = _mapper.Map<CreateLoanDTO>(loan);
            return response;
        }
    }
}
