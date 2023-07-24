using PruebaIngresoBibliotecario.Domain.Entities.Base;
using PruebaIngresoBibliotecario.Domain.Enums;

namespace PruebaIngresoBibliotecario.Domain.Entities
{
    public class User : BaseEntity<string>
    {
        public string Name { get; set; }
        public EnumUserType UserType { get; set; }
    }
}
