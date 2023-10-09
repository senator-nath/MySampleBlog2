using MySampleBlog2.Data;
using MySampleBlog2.Model;

namespace MySampleBlog2.Repository.BlogPostRepository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbContext _db;
        public BlogPostRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool BlogPostExists(string title)
        {
            try
            {
                bool value = _db.BlogPosts.Any(a => a.Title.ToLower().Trim() == title.ToLower().Trim());
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }

        public bool BlogPostExists(int blogPostId)
        {
            try
            {
                return _db.BlogPosts.Any(a => a.Id == blogPostId);
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);


            }

        }

        public bool CreateBlogPost(BlogPost blogPost)
        {
            try
            {
                _db.BlogPosts.Add(blogPost);
                return Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create blogpost", ex);
            }
           ;
        }

        public bool DeleteBlogPost(BlogPost blogPost)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete blogpost", ex);
            }
            _db.BlogPosts.Remove(blogPost);
            return Save();
        }

        public BlogPost GetBlogPost(int blogPostId)
        {
            try
            {
                return _db.BlogPosts.FirstOrDefault(a => a.Id == blogPostId);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get blogpost", ex);
            }

        }

        public ICollection<BlogPost> GetBlogPosts()
        {
            try
            {
                return _db.BlogPosts.OrderBy(a => a.Title).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get blogpost", ex);
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
                throw new Exception("Failed to save blogpost", ex);
            }

        }

        public bool UpdateBlogPost(BlogPost blogPost)
        {
            try
            {
                _db.BlogPosts.Update(blogPost);
                return Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update blogpost", ex);
            }

        }
    }
}

