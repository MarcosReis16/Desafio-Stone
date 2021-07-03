using Stone.Dominio.Classes.Base;
using System;

namespace Stone.Dominio.Classes
{
    /// <summary>
    /// Classe responsável pelo endereço
    /// </summary>
    public class Endereco : ModelBase
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        public Guid UsuarioId { get; private set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        public string Logradouro { get; private set; }

        /// <summary>
        /// Numero
        /// </summary>
        public string Numero { get; private set; }

        /// <summary>
        /// Complemento
        /// </summary>
        public string Complemento { get; private set; }

        /// <summary>
        /// Bairro
        /// </summary>
        public string Bairro { get; private set; }

        /// <summary>
        /// Cep
        /// </summary>
        public string Cep { get; private set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public string Cidade { get; private set; }

        /// <summary>
        /// Estado
        /// </summary>
        public string Estado { get; private set; }

        /// <summary>
        /// País
        /// </summary>
        public string Pais { get; private set; }

        /// <summary>
        /// Usuário
        /// </summary>
        public Usuario Usuario { get; private set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Endereco()
        {

        }

    }
}
