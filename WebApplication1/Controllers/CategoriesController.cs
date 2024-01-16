using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto request)
    {
        // Map DTO to Domain Model
        Category category = new Category()
        {
            Name = request.Name,
            UrlHandle = request.UrlHandle,
        };

        await categoryRepository.CreateAsync(category);

        // Map Domain model to DTO
        CategoryDto response = new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle
        };
        return Ok(response);
    }

    //GET: https://localhost:7071/api/categories
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        IEnumerable<Category> categories = await categoryRepository.GetAllCategoryAsync();
        // Map Domain Model to DTO
        List<CategoryDto> response = new();
        foreach (Category category in categories)
        {
            response.Add(new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            });
        }
        return Ok(response);
    }

    // GET: https://localhost:7071/api/categories/{id}
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
    {
        Category? exisitngCategory = await categoryRepository.GetById(id);
        if (exisitngCategory is null)
        {
            return NotFound();
        }

        CategoryDto response = new()
        {
            Id = exisitngCategory.Id,
            Name = exisitngCategory.Name,
            UrlHandle = exisitngCategory.UrlHandle,
        };

        return Ok(response);
    }

    // PUT:  https://localhost:7071/api/categories/{id}
    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> EditCategory([FromRoute] Guid id, UpdateCategoryRequestDto request)
    {
        // Map DTO to Domain Model
        Category? category = new Category()
        {
            Id = id,
            Name = request.Name,
            UrlHandle = request.UrlHandle,
        };
        category = await categoryRepository.UpdateAsync(category);
        if(category is null)
        {
            return NotFound();
        }
        // Map Domain Model to DTO
        CategoryDto response = new CategoryDto() 
        {
            Id = category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle,

        };

        return Ok(response);

    }

}
