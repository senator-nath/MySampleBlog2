using MySampleBlog2.Model.ModelDto.BlogPostDto;

namespace MySampleBlog2.Services.BlogPostService
{
    public interface IBlogPostService
    {
        List<BlogPostGetDto> GetAll();
        BlogPostDto GetBlogPost(int blogPostId);
        CreateBlogPostDto CreateBlogPost(CreateBlogPostDto blogPostDto);
        UpdateBlogPostDto UpdateBlogPost(UpdateBlogPostDto blogPostDto, int blogPostId);
        DeleteBlogPostDto DeleteBlogPost(int blogPostId);
    }
}
