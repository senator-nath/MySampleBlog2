using System.ComponentModel.DataAnnotations;

namespace MySampleBlog2.Model
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string CreatedAt { get; set; }

        public int UserId { get; set; }
        public int CategoryId { get; set; }


        public List<Comment> Comments { get; set; }
    }
}
