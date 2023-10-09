using MySampleBlog2.Data;
using MySampleBlog2.Model;

namespace MySampleBlog2.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateCategory(Category category)
        {
            {
                try
                {
                    _db.Categories.Add(category);
                    return Save();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to create category", ex);
                }

            }
        }

        public bool DeleteCategory(Category category)
        {
            try
            {
                _db.Categories.Remove(category);
                return Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete blogpost", ex);
            }

        }

        public Category GetCategory(int categoryId)
        {
            try
            {
                return _db.Categories.FirstOrDefault(a => a.Id == categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get blogpost", ex);
            }


        }

        public ICollection<Category> GetCategories()
        {
            try
            {
                return _db.Categories.OrderBy(a => a.Name).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get blogpost", ex);
            }

        }

        public bool CategoryExists(string name)
        {
            try
            {
                bool value = _db.Categories.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }


        }

        public bool CategoryExists(int categoryId)
        {
            try
            {
                return _db.Categories.Any(a => a.Id == categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }

        }

        public bool Save()
        {
            try
            {
                return _db.SaveChanges() >= 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save category", ex);
            }

        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                _db.Categories.Update(category);
                return Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update category", ex);
            }
        }




    }
}

