using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Models.DTO;
using ServiceAPI.Services.Interfaces;

namespace ServiceAPI.Controllers;

[ApiController]
[Route("clients/")]
public class ClientController: ControllerBase
{
    private readonly IClientService _clientService;
    public ClientController(IClientService ClientService)
    {
        _clientService = ClientService;
    }

    [HttpGet]
    public ActionResult<List<ClientDto>> GetAll()
    {
        try
        {
            return _clientService.GetAll();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("by-code")]
    public ActionResult<ClientDto> GetById([FromQuery] int code)
    {
        try
        {
            return _clientService.GetByCode(code);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}