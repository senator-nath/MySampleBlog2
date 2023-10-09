using System.ComponentModel.DataAnnotations;

namespace MySampleBlog2.Model.ModelDto.BlogPostDto
{
    public class CreateBlogPostDto
    {

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string CreatedAt { get; set; }
        public string Message { get; set; }

        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
