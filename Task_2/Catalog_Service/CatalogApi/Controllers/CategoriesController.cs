using Microsoft.AspNetCore.Mvc;
using System.Net;

using BLL.Interfaces;
using CatalogApi.Dto;
using Core.Infrastructure.Models;

namespace CatalogApi.Controllers;

[ApiController]
[Route("api/categories", Name = "general")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly LinkGenerator _linkGenerator;


    public CategoriesController(ICategoryService categoryService, LinkGenerator linkGenerator)
    {
        _categoryService = categoryService;
        _linkGenerator = linkGenerator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryService.GetCategories();
        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(Category category)
    {
        if (category is null)
        {
            return BadRequest("Category is not initialized");
        }

        var result = await _categoryService.AddCategory(category);

        return CreatedAtRoute("general", new { id = category.Id }, category);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(Category category)
    {
        if (category is null)
        {
            return BadRequest("Category is not initialized");
        }

        var result = await _categoryService.UpdateCategory(category);
        return Ok(new LinkDto(_linkGenerator.GetUriByAction(HttpContext, nameof(UpdateCategory), values: new { id = category.Id}),
                    "self",
                    "GET"));
    }

    [HttpDelete]
    public async Task<IActionResult> AddCategory(int id)
    {
        await _categoryService.DeleteCategory(id);
        return Ok(HttpStatusCode.NoContent);
    }
}
