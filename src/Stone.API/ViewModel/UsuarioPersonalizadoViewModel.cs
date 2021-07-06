using Microsoft.AspNetCore.Identity;
using System;

namespace Stone.API.ViewModel
{
    /// <summary>
    /// Classe do usuário personalizada
    /// </summary>
    public class UsuarioPersonalizadoViewModel : IdentityUser
    {
        /// <summary>
        /// Nome
        /// </summary>
        [PersonalData]
        public string Nome { get; set; }

        /// <summary>
        /// Cpf
        /// </summary>
        [PersonalData]
        public string Cpf { get; set; }

        /// <summary>
        /// Data de Nascimento
        /// </summary>
        [PersonalData]
        public DateTime DataDeNascimento { get; set; }

        /// <summary>
        /// Sexo
        /// </summary>
        [PersonalData]
        public int Sexo { get; set; }
    }
}
