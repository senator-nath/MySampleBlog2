using System.ComponentModel.DataAnnotations;

namespace MySampleBlog2.Model.ModelDto.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
