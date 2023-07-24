using System;

namespace PruebaIngresoBibliotecario.Domain.DTOs.Loans
{
    public class CreateLoanDTO
    {
        public Guid Id { get; set; }
        public DateTime FechaMaximaDevolucion { get; set; }
    }
}
