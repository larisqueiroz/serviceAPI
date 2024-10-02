using AutoMapper;
using ServiceAPI.Models.DTO;
using ServiceAPI.Services.Interfaces;

namespace ServiceAPI.Services.Implementations;

public class MessageHandlerService: IHostedService
{
    private IServiceProvider Services { get; }

    public MessageHandlerService(IServiceProvider services)
    {
        Services = services;
    }
    
    public void MessageReceived(object? sender, MessageReceived message)
    {
        using var scope = Services.CreateScope();
        var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IOrderService>();
        var map = scope.ServiceProvider.GetRequiredService<IMapper>();
        
        var order = map.Map<MessageReceived,OrderDto>(message);
        scopedProcessingService.SaveOrder(order, order.ClientCode);
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = Services.CreateScope();
        var rabbitService = scope.ServiceProvider.GetRequiredService<IRabbitMQClientService>();
        rabbitService.RMqMessageReceivedHandler += MessageReceived;
        rabbitService.BuildConnection();
        return Task.CompletedTask;
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}