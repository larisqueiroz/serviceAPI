using AutoMapper;
using ServiceAPI.Models.DAO;
using ServiceAPI.Models.DTO;
using ServiceAPI.Repositories.Interfaces;
using ServiceAPI.Services.Interfaces;

namespace ServiceAPI.Services.Implementations;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    
    public OrderService(IOrderRepository orderRepository, IMapper mapper, IClientRepository clientRepository)
    {
        _orderRepository = orderRepository;
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public List<OrderDto> GetAll()
    {
        return _mapper.Map<List<OrderDto>>(_orderRepository.GetAll());
    }

    public OrderDto GetByCode(int code)
    {
        return _mapper.Map<OrderDto>(_orderRepository.GetByCode(code));
    }

    public List<OrderDto> GetAllByClient(int client)
    {
        return _mapper.Map<List<OrderDto>>(_orderRepository.GetAllByClient(client));
    }
    
    public OrderDto SaveOrder(OrderDto orderDto, int client)
    {
        try
        {
            var saved = _orderRepository.GetByCode(orderDto.Code);
            if (saved is not null)
                throw new BadHttpRequestException("Cliente já cadastrado");
            var order = _mapper.Map<Order>(orderDto);
            order.Id = Guid.NewGuid();
            order.Client = _clientRepository.GetByCode(client);
            order.Code = orderDto.Code;
            order.ClientCode = orderDto.ClientCode;
            orderDto.Itens.ForEach(i =>
            {
                order.Itens.Add(new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = i.Name,
                    Price = i.Price,
                    Quantity = i.Quantity
                });
            });
            _orderRepository.Save(order);

            return orderDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}