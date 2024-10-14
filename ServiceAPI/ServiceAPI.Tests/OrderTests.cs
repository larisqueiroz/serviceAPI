using ServiceAPI.Models.DTO;
using ServiceAPI.Services.Interfaces;
using ServiceAPI.Utils;
using Xunit.Abstractions;
using Type = ServiceAPI.Models.DAO.Type;
using Moq;
using ServiceAPI.Services.Implementations;

namespace ServiceAPI.Tests;

public class OrderTests
{
    private readonly Mock<IOrderService> _orderServiceMock;
    private readonly Mock<IClientService> _clientServiceMock;
    private readonly ITestOutputHelper _testOutputHelper;
    private OrderTotal orderTotal;
    private readonly HttpClient _client;

    public OrderTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        
        _orderServiceMock = new Mock<IOrderService>();
        _clientServiceMock = new Mock<IClientService>();

        orderTotal = new OrderTotal(_orderServiceMock.Object, _clientServiceMock.Object);
    }
    
    [Fact]
    public void SaveOrderTest()
    {
        var messageReceived = new MessageReceived()
        {
            CodigoCliente = 1,
            CodigoPedido = new Random().Next(1, 10000),
            Itens = new List<ItemDto>()
            {
                new ItemDto()
                {
                    Produto = "Esponja",
                    Preco = 5.00,
                    Quantidade = 3
                },
                new ItemDto()
                {
                    Produto = "Detergente",
                    Preco = 3.50,
                    Quantidade = 2
                },
            }
        };
        _orderServiceMock.Setup(s => s.SaveOrder(It.IsAny<MessageReceived>(), It.IsAny<int>()))
            .Returns(new OrderDto());

        var saved = _orderServiceMock.Object.SaveOrder(messageReceived, 1);

        Assert.NotNull(saved);
    }

    [Fact]
    public void GetOrderPriceTest()
    {
        _orderServiceMock.Setup(s => s.GetByCode(It.IsAny<int>()))
            .Returns(new OrderDto
            {
                Itens = new List<ProductDto>
                {
                    new ProductDto { Type = new TypeDto { Price = 10.5 }, Quantity = 2 },
                    new ProductDto { Type = new TypeDto { Price = 20.5 }, Quantity = 1 }
                },
                Code = 9,
                ClientCode = 1
            });
        
        var result = orderTotal.GetOrderPrice(9);
        _testOutputHelper.WriteLine(result);
        
        Assert.NotNull(result);
        Assert.IsType<string>(result);
        Assert.Equal("R$ 41,50", result);
    }
    
    [Fact]
    public void GetOrdersQuantity()
    {
        _orderServiceMock.Setup(s => s.GetAllByClient(It.IsAny<int>()))
            .Returns(new List<OrderDto>
            {
                new OrderDto
                {
                    Code = 9,
                    ClientCode = 15,
                    Client = new ClientDto() {
                        Code = 15
                    },
                    Itens = new List<ProductDto>()
                    {
                        new ProductDto()
                        {
                            Type = new TypeDto()
                            {
                                Name = "Sabão em Barra",
                                Price = 3.50
                            }
                        },
                        new ProductDto()
                        {
                            Type = new TypeDto()
                            {
                                Name = "Shampoo",
                                Price = 12.50
                            }
                        }
                    }
                },
                new OrderDto {
                    Code = 10,
                    Client = new ClientDto()
                    {
                        Code = 15
                    },
                    ClientCode = 15,
                    Itens = new List<ProductDto>()
                    {
                        new ProductDto()
                        {
                            Type = new TypeDto()
                            {
                                Name = "Escova",
                                Price = 7.00
                            }
                        },
                        new ProductDto()
                        {
                            Type = new TypeDto()
                            {
                                Name = "Pasta de Amendoim",
                                Price = 23.99
                            }
                        }
                    }
                }
            });
        
        
        var result = orderTotal.GetOrdersQuantity(15);
        _testOutputHelper.WriteLine(result);
        
        Assert.NotNull(result);
        Assert.IsType<string>(result);
        Assert.Equal("2 pedidos", result);
    }
}