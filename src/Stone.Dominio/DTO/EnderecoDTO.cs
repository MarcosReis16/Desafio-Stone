using System;

namespace Stone.Dominio.DTO
{
    /// <summary>
    /// Classe responsável pelo endereço
    /// </summary>
    public class EnderecoDTO
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        public string Logradouro { get; set; }

        /// <summary>
        /// Numero
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        public string Complemento { get; set; }

        /// <summary>
        /// Cep
        /// </summary>
        public string Cep { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public string Cidade { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// País
        /// </summary>
        public string Pais { get; set; }

    }
}
