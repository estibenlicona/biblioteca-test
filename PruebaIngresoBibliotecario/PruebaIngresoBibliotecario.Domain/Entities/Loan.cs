using PruebaIngresoBibliotecario.Domain.Entities.Base;
using PruebaIngresoBibliotecario.Domain.Enums;
using System;

namespace PruebaIngresoBibliotecario.Domain.Entities
{
    public class Loan : BaseEntity<Guid>
    {
        public  string UserId { get; set; }
        public  EnumUserType UserType { get; set; }
        public  virtual User User { get; set; }
        public  Guid BookId { get; set; }
        public  virtual Book Book { get; set; }
        public  DateTime DeliveryDate { get; set; }
    }
}
