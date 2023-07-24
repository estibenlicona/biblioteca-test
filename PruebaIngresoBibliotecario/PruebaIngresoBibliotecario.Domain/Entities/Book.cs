using PruebaIngresoBibliotecario.Domain.Entities.Base;
using System;

namespace PruebaIngresoBibliotecario.Domain.Entities
{
    public class Book : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}
