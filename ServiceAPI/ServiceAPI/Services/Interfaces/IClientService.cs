using ServiceAPI.Models.DTO;

namespace ServiceAPI.Services.Interfaces;

public interface IClientService
{
    List<ClientDto> GetAll();
    ClientDto GetByCode(int code);
    ClientDto SaveClient(ClientDto clientDto);
}