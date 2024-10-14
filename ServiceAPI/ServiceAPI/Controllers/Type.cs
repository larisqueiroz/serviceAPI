using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Models.DTO;
using ServiceAPI.Services.Interfaces;

namespace ServiceAPI.Controllers;

[ApiController]
[Route("types/")]
public class TypeController: ControllerBase
{
    private readonly ITypeService _typeService;
    public TypeController(ITypeService typeService)
    {
        _typeService = typeService;
    }

    [HttpGet]
    public ActionResult<List<TypeDto>> GetAll()
    {
        try
        {
            return _typeService.GetAll();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("by-name")]
    public ActionResult<TypeDto> GetByName([FromQuery] string name)
    {
        try
        {
            return _typeService.GetByName(name);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}