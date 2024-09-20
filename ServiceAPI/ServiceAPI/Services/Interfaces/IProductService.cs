using ServiceAPI.Models.DTO;

namespace ServiceAPI.Services.Interfaces;

public interface IProductService
{
    List<ProductDto> GetAll();
    ProductDto GetById(Guid id);
}