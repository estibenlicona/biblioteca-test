using AutoMapper;
using PruebaIngresoBibliotecario.Application.Loans.Commands;
using PruebaIngresoBibliotecario.Domain.DTOs.Loans;
using PruebaIngresoBibliotecario.Domain.Entities;

namespace PruebaIngresoBibliotecario.Application.Loans
{
    internal class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<CreateLoanCommand, Loan>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.IdentificacionUsuario))
                .ForMember(x => x.UserType, opt => opt.MapFrom(x => x.TipoUsuario))
                .ForMember(x => x.BookId, opt => opt.MapFrom(x => x.ISBN));

            CreateMap<Loan, FindLoanDTO>()
                .ForMember(x => x.ISBN, opt => opt.MapFrom(x => x.BookId))
                .ForMember(x => x.IdentificacionUsuario, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.TipoUsuario, opt => opt.MapFrom(x => x.UserType))
                .ForMember(x => x.FechaMaximaDevolucion, opt => opt.MapFrom(x => x.DeliveryDate));

            CreateMap<Loan, CreateLoanDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.FechaMaximaDevolucion, opt => opt.MapFrom(x => x.DeliveryDate));
        }
    }
}
