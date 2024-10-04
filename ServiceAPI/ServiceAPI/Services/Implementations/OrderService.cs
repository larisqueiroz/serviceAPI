using AutoMapper;
using ServiceAPI.Models.DAO;
using ServiceAPI.Models.DTO;
using ServiceAPI.Repositories.Interfaces;
using ServiceAPI.Services.Interfaces;
using Type = ServiceAPI.Models.DAO.Type;

namespace ServiceAPI.Services.Implementations;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ITypeRepository _typeRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    
    public OrderService(IOrderRepository orderRepository, IMapper mapper, IClientRepository clientRepository,
        ITypeRepository typeRepository)
    {
        _orderRepository = orderRepository;
        _clientRepository = clientRepository;
        _mapper = mapper;
        _typeRepository = typeRepository;
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
    
    public OrderDto SaveOrder(MessageReceived orderDto, int client)
    {
        try
        {
            List<Product> products = new List<Product>();
            
            var saved = _orderRepository.GetByCode(orderDto.CodigoPedido);
            if (saved is not null)
                throw new BadHttpRequestException("Pedido já cadastrado");
            
            var savedClient = _clientRepository.GetByCode(client);
            if (savedClient is null)
                _clientRepository.Save(new Client(){Code = client});

            foreach (var product in orderDto.Itens)
            {
                var savedType = _typeRepository.GetByName(product.Produto);
                if (savedType is null)
                    _typeRepository.Save(new Type(){Name = product.Produto, Price = product.Preco});
                products.Add(new Product()
                {
                    Quantity = product.Quantidade,
                    Type = _typeRepository.GetByName(product.Produto),
                    Id = Guid.NewGuid()
                });
            }

            var order = new Order();
            order.Id = Guid.NewGuid();
            order.Client = _clientRepository.GetByCode(client);
            order.Code = orderDto.CodigoPedido;
            order.ClientCode = orderDto.CodigoCliente;
            order.Itens = products;
            _orderRepository.Save(order);

            return _mapper.Map<OrderDto>(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}