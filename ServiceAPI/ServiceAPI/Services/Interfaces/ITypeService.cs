using ServiceAPI.Models.DTO;

namespace ServiceAPI.Services.Interfaces;

public interface ITypeService
{
    List<TypeDto> GetAll();
    TypeDto GetById(Guid id);
    TypeDto GetByName(string name);
}