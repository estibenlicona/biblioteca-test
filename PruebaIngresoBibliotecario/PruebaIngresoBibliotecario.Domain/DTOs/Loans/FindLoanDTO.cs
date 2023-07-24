using PruebaIngresoBibliotecario.Domain.Enums;
using System;

namespace PruebaIngresoBibliotecario.Domain.DTOs.Loans
{
    public class FindLoanDTO
    {
        public Guid Id { get; set; }
        public Guid ISBN { get; set; }
        public string IdentificacionUsuario { get; set; }
        public EnumUserType TipoUsuario { get; set; }
        public DateTime FechaMaximaDevolucion { get; set; }
    }
}
