using PruebaIngresoBibliotecario.Domain.Entities;
using PruebaIngresoBibliotecario.Domain.Enums;
using System.Collections.Generic;

namespace PruebaIngresoBibliotecario.Infrastructure.Seeds
{
    public static class UserSeed
    {
        public static IEnumerable<User> GetUsersSeeds()
        {
            return new List<User>
            {
                new User { Id = "123456789", Name = "Estiben Puerta", UserType = EnumUserType.Guest },
                new User { Id = "1234568", Name = "Alejandro Osorio", UserType = EnumUserType.Affiliate },
                new User { Id = "1024879856", Name = "Eduardo Murcia", UserType = EnumUserType.Employee }
            };
        }
    }
}
