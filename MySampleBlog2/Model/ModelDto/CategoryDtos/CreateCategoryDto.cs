using System.ComponentModel.DataAnnotations;

namespace MySampleBlog2.Model.ModelDto.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
