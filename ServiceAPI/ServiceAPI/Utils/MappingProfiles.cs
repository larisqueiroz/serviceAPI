using AutoMapper;
using ServiceAPI.Models.DAO;
using ServiceAPI.Models.DTO;
using Type = ServiceAPI.Models.DAO.Type;

namespace ServiceAPI.Utils;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Client, ClientDto>();
        CreateMap<ClientDto, Client>();
        
        CreateMap<Product, ProductDto>().ForMember(i => i.Type, opt => opt.MapFrom(p => p.Type));;
        CreateMap<ProductDto, Product>();
        
        CreateMap<Type, TypeDto>();
        CreateMap<TypeDto, Type>();
        
        CreateMap<Order, OrderDto>().ForMember(i => i.Itens, opt => opt.MapFrom(p => p.Itens));
        CreateMap<OrderDto, Order>();
    }
}