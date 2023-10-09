using MySampleBlog2.Model;

namespace MySampleBlog2.Repository.BlogPostRepository
{
    public interface IBlogPostRepository
    {
        ICollection<BlogPost> GetBlogPosts();

        bool BlogPostExists(string Name);
        bool BlogPostExists(int blogPostId);
        bool CreateBlogPost(BlogPost blogPost);
        bool UpdateBlogPost(BlogPost blogPost);
        BlogPost GetBlogPost(int blogPostId);
        bool DeleteBlogPost(BlogPost blogPost);
        bool Save();
    }
}
