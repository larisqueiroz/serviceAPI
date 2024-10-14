using ServiceAPI.Models.DTO;

namespace ServiceAPI.Services.Interfaces;

public interface IMessageHandlerService: IHostedService
{
    public event EventHandler<MessageReceived>? RMqMessageReceivedHandler;
}