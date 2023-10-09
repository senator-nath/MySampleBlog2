using Microsoft.AspNetCore.Mvc;
using MySampleBlog2.Model.ModelDto.CategoryDtos;
using MySampleBlog2.Services.CategoryService;

namespace MySampleBlog2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("get-Category")]
        [ProducesResponseType(200, Type = typeof(List<CategoryGetDto>))]
        public IActionResult GetCategories()
        {
            try
            {
                var result = _categoryService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while getting the category: " + ex.Message);

            }
        }

        /// <summary>
        /// get individual national park
        /// </summary>
        /// <param name="categoryId">the id of the national park</param>
        /// <returns></returns>
        [HttpGet("{categoryId:int}/GetNationalPark")]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetCategory(int categoryId)
        {
            try
            {
                var result = _categoryService.GetCategory(categoryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while getting the category: " + ex.Message);
            }
        }
        [HttpPost("create-Category")]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            try
            {
                var result = _categoryService.CreateCategory(categoryDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the category: " + ex.Message);
            }
        }
        [HttpPatch("{categoryId:int}/UpdateCategory")]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryDto categoryDto)
        {
            try
            {
                var result = _categoryService.UpdateCategory(categoryDto, categoryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the category: " + ex.Message);
            }

        }
        [HttpDelete("{categoryId:int}/DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCategories(int categoryId)
        {
            try
            {
                var result = _categoryService.DeleteCategory(categoryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the category: " + ex.Message);
            }

        }
    }
}
