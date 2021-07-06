using System;
using System.Runtime.Serialization;

namespace Stone.Dominio.Excecoes
{
    /// <summary>
    /// Exceção de Negócio
    /// </summary>
    public class ExcecaoDeNegocio : Exception
    {
        public ExcecaoDeNegocio(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public ExcecaoDeNegocio()
            : base() { }

        public ExcecaoDeNegocio(string message)
            : base(message) { }

        public ExcecaoDeNegocio(string message, Exception exception)
            : base(message, exception) { }

        public ExcecaoDeNegocio(Exception exception)
            : base(exception.Message, exception) { }
    }
}
