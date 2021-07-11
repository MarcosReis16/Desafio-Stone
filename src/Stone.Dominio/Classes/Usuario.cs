using Microsoft.AspNetCore.Identity;
using Stone.Dominio.DTO;
using System;
using System.Collections.Generic;

namespace Stone.Dominio.Classes
{
    /// <summary>
    /// Classe responsável pelo usuário
    /// </summary>
    public class Usuario : IdentityUser<Guid>
    {
        /// <summary>
        /// Nome
        /// </summary>
        [PersonalData]
        public string Nome { get; private set; }

        /// <summary>
        /// Cpf
        /// </summary>
        [PersonalData]
        public string Cpf { get; private set; }

        /// <summary>
        /// Data de Nascimento
        /// </summary>
        [PersonalData]
        public DateTime DataDeNascimento { get; private set; }

        /// <summary>
        /// Sexo
        /// </summary>
        [PersonalData]
        public int Sexo { get; private set; }

        /// <summary>
        /// Endereco
        /// </summary>
        public Endereco Endereco { get; private set; }

        /// <summary>
        /// Transações efetuadas pelo usuário
        /// </summary>
        public IList<Transacao> Transacoes { get; private set; }

        /// <summary>
        /// Cartões salvos pelo usuário
        /// </summary>
        public IList<UsuarioCartao> UsuarioCartoes { get; private set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Usuario() : base()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="id">Id</param>
        public Usuario(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Método para criar um usuário identity
        /// </summary>
        /// <param name="usuario">Usuário de Registro</param>
        /// <returns>Usuário</returns>
        public static Usuario Create(UsuarioDeRegistroDTO usuario) => new()
        {
            Id = Guid.NewGuid(),
            Email = usuario.Email,
            EmailConfirmed = true,
            UserName = usuario.Email,
            Nome = usuario.Nome,
            Cpf = usuario.Cpf,
            DataDeNascimento = usuario.DataDeNascimento,
            Sexo = usuario.Sexo,
            Endereco = new Endereco(usuario.Endereco),
        };

        

    }
}
