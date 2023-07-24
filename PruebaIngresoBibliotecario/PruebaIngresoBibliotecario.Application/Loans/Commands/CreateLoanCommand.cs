using MediatR;
using PruebaIngresoBibliotecario.Domain.DTOs.Loans;
using PruebaIngresoBibliotecario.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaIngresoBibliotecario.Application.Loans.Commands
{
    public class CreateLoanCommand : IRequest<CreateLoanDTO>
    {
        [RegularExpression(@"^[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}$")]
        public Guid ISBN { get; set; }
        [StringLength(10)]
        public string IdentificacionUsuario { get; set; }
        [EnumDataType(typeof(EnumUserType))]
        public EnumUserType TipoUsuario { get; set; }
    }
}
