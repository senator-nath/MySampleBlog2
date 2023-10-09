using MySampleBlog2.Model;

namespace MySampleBlog2.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {


        ICollection<Category> GetCategories();

        bool CategoryExists(string Name);
        bool CategoryExists(int id);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        Category GetCategory(int id);
        bool DeleteCategory(Category category);
        bool Save();
    }
}
