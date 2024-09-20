using AutoMapper;
using ServiceAPI.Models.DAO;
using ServiceAPI.Models.DTO;
using ServiceAPI.Repositories.Interfaces;
using ServiceAPI.Services.Interfaces;

namespace ServiceAPI.Services.Implementations;

public class ClientService: IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    
    public ClientService(IClientRepository clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public List<ClientDto> GetAll()
    {
        return _mapper.Map<List<ClientDto>>(_clientRepository.GetAll());
    }

    public ClientDto GetByCode(int code)
    {
        return _mapper.Map<ClientDto>(_clientRepository.GetByCode(code));
    }

    public ClientDto SaveClient(ClientDto clientDto)
    {
        try
        {
            var saved = _clientRepository.GetByCode(clientDto.Code);
            if (saved is not null)
                throw new BadHttpRequestException("Cliente já cadastrado");
            var client = _mapper.Map<Client>(clientDto);
            client.Id = Guid.NewGuid();
            _clientRepository.Save(client);

            return clientDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}