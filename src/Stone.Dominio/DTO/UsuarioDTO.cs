using System;

namespace Stone.Dominio.DTO
{
    /// <summary>
    /// Usuário DTO
    /// </summary>
    public class UsuarioDTO
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Cpf
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Data de Nascimento
        /// </summary>
        public DateTime DataDeNascimento { get; set; }

        /// <summary>
        /// Sexo
        /// </summary>
        public int Sexo { get; set; }

        /// <summary>
        /// Endereço
        /// </summary>
        public EnderecoDTO Endereco { get; set; }
    }
}
