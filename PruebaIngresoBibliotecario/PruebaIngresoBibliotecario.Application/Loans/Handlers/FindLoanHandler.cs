using AutoMapper;
using MediatR;
using PruebaIngresoBibliotecario.Application.Loans.Queries;
using PruebaIngresoBibliotecario.Domain.DomainServices.Loans;
using PruebaIngresoBibliotecario.Domain.DTOs.Loans;
using PruebaIngresoBibliotecario.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Application.Loans.Handlers
{
    internal class FindLoanHandler : IRequestHandler<FindLoanQuery, FindLoanDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILoanService _loanService;
        public FindLoanHandler(IMapper mapper, ILoanService loanService)
        {
            _loanService = loanService;
            _mapper = mapper;
        }
        public async Task<FindLoanDTO> Handle(FindLoanQuery query, CancellationToken cancellationToken)
        {
            Loan loan = await _loanService.FindAsync(query.Id);
            FindLoanDTO responseLoan = _mapper.Map<FindLoanDTO>(loan);
            return responseLoan;
        }
    }
}
