using System.ComponentModel.DataAnnotations;

namespace MySampleBlog2.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public List<BlogPost> BlogPost { get; set; }
    }
}
