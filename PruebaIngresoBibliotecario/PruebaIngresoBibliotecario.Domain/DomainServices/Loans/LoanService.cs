using PruebaIngresoBibliotecario.Domain.Entities;
using PruebaIngresoBibliotecario.Domain.Enums;
using PruebaIngresoBibliotecario.Domain.Exceptions;
using PruebaIngresoBibliotecario.Domain.Ports;
using System;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Domain.DomainServices.Loans
{
    public class LoanService : ILoanService
    {
        private readonly IGenericRepository<Loan, Guid> _genericRepository;
        public LoanService(IGenericRepository<Loan, Guid> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Loan> AddAsync(Loan loan)
        {
            if (loan.UserType == EnumUserType.Guest) await ValidateLoansGuest(loan.UserId);
            loan.DeliveryDate = GetDeliveryDate(loan.UserType);
            await _genericRepository.AddAsync(loan);
            return loan;
        }

        public async Task<Loan> FindAsync(Guid id)
        {
            Loan loan = await _genericRepository.FindAsync(x => x.Id.Equals(id));
            if (loan == null) throw new DomainException($"El prestamo con id {id} no existe", 404);
            return loan;
        }

        public DateTime GetDeliveryDate(EnumUserType userType)
        {
            DateTime deliveryDate = DateTime.Now;
            switch (userType)
            {   
                case EnumUserType.Affiliate:
                    deliveryDate = AddBusinessDays(deliveryDate, 10);
                    break;
                case EnumUserType.Employee:
                    deliveryDate = AddBusinessDays(deliveryDate, 8);
                    break;
                case EnumUserType.Guest:
                    deliveryDate = AddBusinessDays(deliveryDate, 7);
                    break;
                default: 
                    break;
            }
            return deliveryDate;
        }

        public async Task ValidateLoansGuest(string userId)
        {
            bool isInvalid = await _genericRepository.AnyAsync(x => x.UserId.Equals(userId));
            if (isInvalid)
            {
                throw new DomainException($"El usuario con identificacion {userId} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo", 400);
            }
        }

        public DateTime AddBusinessDays(DateTime date, int days)
        {
            int daysToAdd = 0;
            while (daysToAdd < days)
            {
                date = date.AddDays(1);
                if (IsBussinessDay(date)) daysToAdd++;
            }
            return date;
        }

        public bool IsBussinessDay(DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday; 
        }
    }
}
