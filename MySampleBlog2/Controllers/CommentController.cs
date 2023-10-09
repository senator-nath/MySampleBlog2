using Microsoft.AspNetCore.Mvc;
using MySampleBlog2.Model.ModelDto.CommentDto;
using MySampleBlog2.Services.CommentService;

namespace MySampleBlog2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpGet("get-Comment")]
        [ProducesResponseType(200, Type = typeof(List<CommentGetDto>))]
        public IActionResult GetCategories()
        {
            try
            {
                var result = _commentService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while getting the comment: " + ex.Message);

            }
        }

        /// <summary>
        /// get individual national park
        /// </summary>
        /// <param name="commentId">the id of the national park</param>
        /// <returns></returns>
        [HttpGet("{commentId:int}/GetComment")]
        [ProducesResponseType(200, Type = typeof(CommentDto))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetComment(int commentId)
        {
            try
            {
                var result = _commentService.GetComment(commentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while getting the comment: " + ex.Message);
            }

        }
        [HttpPost("create-Comment")]
        [ProducesResponseType(200, Type = typeof(CommentDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateComment([FromBody] CreateCommentDto commentDto)
        {
            try
            {
                var result = _commentService.CreateComment(commentDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the comment: " + ex.Message);

            }

        }
        [HttpPatch("{commentId:int}/UpdateComment")]
        [ProducesResponseType(200, Type = typeof(CommentDto))]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateComment(int commentId, [FromBody] UpdateCommentDto commentDto)
        {
            try
            {
                var result = _commentService.UpdateComment(commentDto, commentId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while updating the comment: " + ex.Message);
            }
        }
        [HttpDelete("{commentId:int}/DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteComment(int commentId)
        {
            try
            {
                var result = _commentService.DeleteComment(commentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the comment: " + ex.Message);
            }
        }
    }
}
