using Microsoft.AspNetCore.Mvc;

namespace ServiceAPI.Controllers;

[ApiController]
[Route("clients/")]
public class ProductController: ControllerBase
{
    public ProductController()
    {
        
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        throw new NotImplementedException();
    }
}