using System;

namespace Stone.Dominio.Classes.Base
{
    /// <summary>
    /// Classe base
    /// </summary>
    public abstract class ModelBase
    {
        public Guid Id { get; protected set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        protected ModelBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
