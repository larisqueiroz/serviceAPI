using ServiceAPI.Models.DTO;

namespace ServiceAPI.Services.Interfaces;

public interface IRabbitMQClientService
{
    public void BuildConnection();
    public event EventHandler<MessageReceived>? RMqMessageReceivedHandler;
}