using AutoMapper;
using ServiceAPI.Models.DAO;
using ServiceAPI.Models.DTO;

namespace ServiceAPI.Utils;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Client, ClientDto>();
        CreateMap<ClientDto, Client>();
        
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
        
        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>();
        
        CreateMap<ItemDto, ProductDto>().ForMember(i => i.Name, opt => opt.MapFrom(p => p.Produto))
            .ForMember(i => i.Quantity, opt => opt.MapFrom(p => p.Quantidade))
            .ForMember(i => i.Price, opt => opt.MapFrom(p => p.Preco));
        
        CreateMap<MessageReceived, OrderDto>().ForMember(i => i.ClientCode, opt => opt.MapFrom(p => p.CodigoCliente))
        .ForMember(i => i.Code, opt => opt.MapFrom(p => p.CodigoPedido))
        .ForMember(i => i.Itens, opt => opt.MapFrom(p => p.Itens));
    }
}