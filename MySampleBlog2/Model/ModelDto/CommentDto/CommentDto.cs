using System.ComponentModel.DataAnnotations;

namespace MySampleBlog2.Model.ModelDto.CommentDto
{
    public class CommentDto
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        public int BlogPostId { get; set; }

        public int UserId1 { get; set; }
        public string Message { get; set; }
    }
}
