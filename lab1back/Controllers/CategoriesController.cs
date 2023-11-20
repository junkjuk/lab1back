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
    public IActionResult Get(Guid id)
    {
        try
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category is null)
                return NotFound();

            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpDelete("category/{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _categoryRepository.DeleteCategory(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpPost("category")]
    public IActionResult Add([FromBody]string name)
    {
        try
        {
            _categoryRepository.AddCategory(new Category{Name = name, Id = Guid.NewGuid()});
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}