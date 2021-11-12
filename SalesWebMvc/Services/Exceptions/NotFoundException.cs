using System;

namespace SalesWebMvc.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        // Para passar a mensagem para a class base usamos a anotação : base (nome dá variavel)
        public NotFoundException( string message) : base (message)
        {
        }
    }
}
