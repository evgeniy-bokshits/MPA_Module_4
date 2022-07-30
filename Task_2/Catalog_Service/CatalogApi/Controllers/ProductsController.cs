using Microsoft.AspNetCore.Mvc;
using System.Net;

using BLL.Interfaces;
using CatalogApi.Models;
using Core.Infrastructure.Models;

namespace CatalogApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] FilterModel filter)
    {
        var products = await _productService.GetProducts(filter.CategoryId, filter.Skip, filter.Count);
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        if (product is null)
        {
            return BadRequest("Product is not initialized");
        }

        var result = await _productService.AddProduct(product);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(Product product)
    {
        if (product is null)
        {
            return BadRequest("Product is not initialized");
        }

        var result = await _productService.UpdateProduct(product);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProduct(id);
        return Ok(HttpStatusCode.NoContent);
    }
}
