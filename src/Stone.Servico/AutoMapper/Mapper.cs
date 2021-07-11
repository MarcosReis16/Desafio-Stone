using AutoMapper;
using Stone.Dominio.Classes;
using Stone.Dominio.DTO;

namespace Stone.Servico.AutoMapper
{
    /// <summary>
    /// Classe de Mapeamento
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

            profile.CreateMap<Aplicativo, AplicativoDTO>()
                   .ReverseMap();
            
            profile.CreateMap<UsuarioCartao, UsuarioCartaoDTO>()
                   .ReverseMap();

            profile.CreateMap<Cartao, CartaoDTO>()
                   .ReverseMap();

            profile.CreateMap<Transacao, TransacaoDTO>()
                   .ForPath(t => t.Usuario.Id, t => t.MapFrom(tr => tr.IdUsuario))
                   .ForPath(t => t.Aplicativo.Id, t => t.MapFrom(tr => tr.IdAplicativo))
                   .ForPath(t => t.Cartao.Id, t => t.MapFrom(tr => tr.IdCartao))
                   .ReverseMap();


        }
    }
}
