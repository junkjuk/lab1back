using Entities;
using lab1back.Logic;
using lab1back.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab1back.Controllers;

[ApiController]
public class CategoriesController : ControllerBase
{

    private readonly ICategoryRepository _categoryRepository;
    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    [HttpGet("category/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category is null)
                return NotFound();

            return Ok(category);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpDelete("category/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _categoryRepository.DeleteCategory(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpPost("category")]
    public async Task<IActionResult> Add([FromBody]string name)
    {
        try
        {
            var category = new Category {Name = name, Id = Guid.NewGuid()};
            await _categoryRepository.AddCategory(category);
            return Ok(category.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}