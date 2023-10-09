using System.ComponentModel.DataAnnotations;

namespace MySampleBlog2.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        public int BlogPostId { get; set; }

        public int UserId1 { get; set; }

    }
}
