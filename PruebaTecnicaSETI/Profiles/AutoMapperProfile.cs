using AutoMapper;

namespace PruebaTecnicaSETI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<PetiticionPedidos, ResponseXml>()
            //    .ForMember(dest => dest.pedido, opt => opt.MapFrom(src => src.enviarPedido.numPedido))
            //    .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.enviarPedido.cantidadPedido))
            //    .ForMember(dest => dest.EAN, opt => opt.MapFrom(src => src.enviarPedido.codigoEAN))
            //    .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.enviarPedido.nombreProducto))
            //    .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.enviarPedido.numDocumento))
            //    .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.enviarPedido.direccion));
        }
    }
}
