using PruebaIngresoBibliotecario.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Domain.DomainServices.Loans
{
    public interface ILoanService
    {
        Task<Loan> FindAsync(Guid id);
        Task<Loan> AddAsync(Loan loan);
    }
}
