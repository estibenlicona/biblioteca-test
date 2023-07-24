using System;

namespace PruebaIngresoBibliotecario.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public int HttpStatusCode { get; }
        public DomainException(string mensaje, int httpStatusCode) : base(mensaje) 
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
