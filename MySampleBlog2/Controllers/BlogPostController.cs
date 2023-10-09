using Microsoft.AspNetCore.Mvc;
using MySampleBlog2.Model.ModelDto.BlogPostDto;
using MySampleBlog2.Services.BlogPostService;

namespace MySampleBlog2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;
        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet("get-BlogPost")]
        [ProducesResponseType(200, Type = typeof(List<BlogPostDto>))]
        public IActionResult GetCategories()
        {
            try
            {
                var result = _blogPostService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the BlogPost: " + ex.Message);
            }

        }

        /// <summary>
        /// get individual national park
        /// </summary>
        /// <param name="blogPostId">the id of the national park</param>
        /// <returns></returns>
        [HttpGet("{blogPostId:int}/GetBlogPost")]
        [ProducesResponseType(200, Type = typeof(BlogPostDto))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetBlogPost(int blogPostId)
        {
            try
            {
                var result = _blogPostService.GetBlogPost(blogPostId);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while getting the BlogPost : " + ex.Message);
            }
        }
        [HttpPost("create-BlogPost")]
        [ProducesResponseType(200, Type = typeof(BlogPostDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateBlogPost([FromBody] CreateBlogPostDto blogPostDto)
        {
            try
            {
                var result = _blogPostService.CreateBlogPost(blogPostDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the BlogPost: " + ex.Message);
            }

        }
        [HttpPatch("{blogPostId:int}/UpdateBlogPost")]
        [ProducesResponseType(200, Type = typeof(BlogPostDto))]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCategory(int blogPostId, [FromBody] UpdateBlogPostDto blogPostDto)
        {
            try
            {
                var result = _blogPostService.UpdateBlogPost(blogPostDto, blogPostId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the BlogPost: " + ex.Message);
            }
        }
        [HttpDelete("{blogPostId:int}/DeleteblogPost")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCategories(int blogPostId)
        {
            try
            {
                var result = _blogPostService.DeleteBlogPost(blogPostId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the BlogPost: " + ex.Message);
            }


        }
    }
}
