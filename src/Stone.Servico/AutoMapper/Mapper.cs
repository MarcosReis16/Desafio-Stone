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
            profile.CreateMap<Usuario, UsuarioDTO>()
                   .ReverseMap();
            profile.CreateMap<Endereco, EnderecoDTO>()
                   .ReverseMap();

            profile.CreateMap<Transacao, TransacaoDTO>()
                   .ForMember(t => t.Usuario.Id, t => t.MapFrom(tr => tr.IdUsuario))
                   .ForMember(t => t.Aplicativo.Id, t => t.MapFrom(tr => tr.IdAplicativo))
                   .ForMember(t => t.Cartao.Id, t => t.MapFrom(tr => tr.IdCartao))
                   .ReverseMap();

            profile.CreateMap<Cartao, CartaoDTO>()
                   .ForMember(c => c.Usuario.Id, act => act.MapFrom(src => src.IdUsuario))
                   .ReverseMap();
        }
    }
}
