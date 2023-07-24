using MediatR;
using PruebaIngresoBibliotecario.Domain.DTOs.Loans;
using System;

namespace PruebaIngresoBibliotecario.Application.Loans.Queries
{
    public class FindLoanQuery : IRequest<FindLoanDTO>
    {
        public Guid Id { get; set; }
    }
}
