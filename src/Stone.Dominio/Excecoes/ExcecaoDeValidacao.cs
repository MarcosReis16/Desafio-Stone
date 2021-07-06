using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Stone.Dominio.Excecoes
{
    /// <summary>
    /// Excecão de validação
    /// </summary>
    public class  ExcecaoDeValidacao : Exception
    {
        /// <summary>
        /// Falhas
        /// </summary>
        public IList<string> Falhas { get; set; }

        public ExcecaoDeValidacao(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public ExcecaoDeValidacao()
            : base() { }

        public ExcecaoDeValidacao(string message)
            : base(message) { }

        public ExcecaoDeValidacao(string message, Exception exception)
            : base(message, exception) { }

        public ExcecaoDeValidacao(Exception exception)
            : base(exception.Message, exception) { }

        public ExcecaoDeValidacao(IList<string> falhas)
        {
            Falhas = falhas;
        }
    }
}
