using System;
using System.Runtime.Serialization;

namespace Stone.Dominio.Excecoes
{
    /// <summary>
    /// Exceção de erro interno
    /// </summary>
    public class ExcecaoDeErroInterno : Exception
    {
        public ExcecaoDeErroInterno(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public ExcecaoDeErroInterno()
            : base() { }

        public ExcecaoDeErroInterno(string message)
            : base(message) { }

        public ExcecaoDeErroInterno(string message, Exception exception)
            : base(message, exception) { }

        public ExcecaoDeErroInterno(Exception exception)
            : base(exception.Message, exception) { }
    }
}
