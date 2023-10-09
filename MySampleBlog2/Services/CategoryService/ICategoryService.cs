using MySampleBlog2.Model.ModelDto.CategoryDtos;

namespace MySampleBlog2.Services.CategoryService
{
    public interface ICategoryService
    {
        List<CategoryGetDto> GetAll();
        CategoryDto GetCategory(int CategoryId);
        CreateCategoryDto CreateCategory(CreateCategoryDto categoryDto);
        UpdateCategoryDto UpdateCategory(CategoryDto categoryDto, int categoryId);
        DeleteCategoryDto DeleteCategory(int categoryId);
    }
}
