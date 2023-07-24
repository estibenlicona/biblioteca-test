using PruebaIngresoBibliotecario.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PruebaIngresoBibliotecario.Infrastructure.Seeds
{
    public static class BookSeed
    {
        public static IEnumerable<Book> GetBooksSeeds()
        {
            return new List<Book>
            {
                new Book { Id = Guid.Parse("5c493736-2762-491b-ac8d-52d06f461560"), Name = "EL principito" },
                new Book { Id = Guid.Parse("181215c5-b0a4-47c2-bb90-d5f47c0fdf0d"), Name = "El olvido que seremos" },
                new Book { Id = Guid.Parse("e7a89d35-b263-46ad-bf09-bab5a73d3b49"), Name = "El coronel no tiene quien le escriba" }
            };
        }
    }
}
