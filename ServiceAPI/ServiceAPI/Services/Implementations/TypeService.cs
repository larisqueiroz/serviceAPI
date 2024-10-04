using AutoMapper;
using ServiceAPI.Models.DTO;
using ServiceAPI.Repositories.Interfaces;
using ServiceAPI.Services.Interfaces;

namespace ServiceAPI.Services.Implementations;

public class TypeService: ITypeService
{
    private readonly ITypeRepository _TypeRepository;
    private readonly IMapper _mapper;
    
    public TypeService(ITypeRepository TypeRepository, IMapper mapper)
    {
        _TypeRepository = TypeRepository;
        _mapper = mapper;
    }

    public List<TypeDto> GetAll()
    {
        return _mapper.Map<List<TypeDto>>(_TypeRepository.GetAll());
    }

    public TypeDto GetById(Guid id)
    {
        return _mapper.Map<TypeDto>(_TypeRepository.GetById(id));
    }
    
    public TypeDto GetByName(string name)
    {
        return _mapper.Map<TypeDto>(_TypeRepository.GetByName(name));
    }
}