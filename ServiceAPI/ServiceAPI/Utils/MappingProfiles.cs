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
    }
}