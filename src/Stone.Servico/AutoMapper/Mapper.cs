using AutoMapper;
using Stone.Dominio.Classes;
using Stone.Dominio.DTO;

namespace Stone.Servico.AutoMapper
{
    /// <summary>
    /// Classe de 
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Método de mapeamento das entidades
        /// </summary>
        /// <param name="profile">Profile</param>
        public static void Map(this Profile profile)
        {
            profile.CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            profile.CreateMap<Endereco, EnderecoDTO>().ReverseMap();
        }
    }
}
