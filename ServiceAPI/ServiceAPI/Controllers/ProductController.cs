﻿using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Models.DTO;
using ServiceAPI.Services.Interfaces;

namespace ServiceAPI.Controllers;

[ApiController]
[Route("products/")]
public class ProductController: ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<List<ProductDto>> GetAll()
    {
        try
        {
            return _productService.GetAll();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("by-id")]
    public ActionResult<ProductDto> GetById([FromQuery] Guid id)
    {
        try
        {
            return _productService.GetById(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}