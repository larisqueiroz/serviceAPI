using AutoMapper;
using ServiceAPI.Models.DTO;
using ServiceAPI.Repositories.Interfaces;
using ServiceAPI.Services.Interfaces;

namespace ServiceAPI.Services.Implementations;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public List<ProductDto> GetAll()
    {
        return _mapper.Map<List<ProductDto>>(_productRepository.GetAll());
    }

    public ProductDto GetById(Guid id)
    {
        return _mapper.Map<ProductDto>(_productRepository.GetById(id));
    }
}