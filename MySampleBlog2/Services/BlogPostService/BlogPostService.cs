using AutoMapper;
using MySampleBlog2.Model;
using MySampleBlog2.Model.ModelDto.BlogPostDto;
using MySampleBlog2.Repository.BlogPostRepository;

namespace MySampleBlog2.Services.BlogPostService
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepo;
        public BlogPostService(IBlogPostRepository blogPostRepo, IMapper mapper)
        {
            _blogPostRepo = blogPostRepo;
            _mapper = mapper;
        }
        public CreateBlogPostDto CreateBlogPost(CreateBlogPostDto blogPostDto)
        {
            Console.WriteLine($"inside create BlogPost controller");
            var response = new CreateBlogPostDto();
            try
            {
                if (blogPostDto == null)
                {
                    return null;
                }
                if (_blogPostRepo.BlogPostExists(blogPostDto.Title))
                {

                    response.Message = "Category already exist";
                    return response;
                }

                // var nationalParkObj = _mapper.Map<NationalParks>(nationalParkDto);
                var BP = new BlogPost
                {
                    Title = blogPostDto.Title,
                    Content = blogPostDto.Content,
                    CreatedAt = DateTime.Now.ToString("dd-MMMM-yyyy")
                };
                var res = _blogPostRepo.CreateBlogPost(BP);
                if (res)
                {
                    response = new CreateBlogPostDto()
                    {
                        Title = blogPostDto.Title,
                        Content = blogPostDto.Content,
                        CreatedAt = DateTime.Now.ToString("dd-MMMM-yyyy")
                    };
                    return response;
                }
                response.Message = "an error has occured";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred: " + ex.Message;
                return response;
            }

        }

        public DeleteBlogPostDto DeleteBlogPost(int blogPostId)
        {
            var response = new DeleteBlogPostDto();
            try
            {
                if (!_blogPostRepo.BlogPostExists(blogPostId))
                {
                    response.Message = "Category does not exist";
                    return response;
                }

                var blogPostObj = _blogPostRepo.GetBlogPost(blogPostId);
                if (!_blogPostRepo.DeleteBlogPost(blogPostObj))
                {
                    response.Message = $"Somthing went wrong when deleting the records {blogPostObj.Title}";

                    return response;
                }
                response.Message = "No content";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred: " + ex.Message;
                return response;
            }

        }

        public List<BlogPostGetDto> GetAll()
        {
            try
            {
                var objList = _blogPostRepo.GetBlogPosts();
                var objDto = new List<BlogPostGetDto>();

                foreach (var obj in objList)
                {
                    objDto.Add(_mapper.Map<BlogPostGetDto>(obj));
                }
                return objDto;
            }
            catch
            {
                return new List<BlogPostGetDto>();
            }
        }

        public BlogPostDto GetBlogPost(int blogPostId)
        {

            var resp = new BlogPostDto();
            try
            {
                var obj = _blogPostRepo.GetBlogPost(blogPostId);
                if (obj == null)
                {
                    resp.Message = "Incorrect ID";
                    return resp;
                }
                var objDto = _mapper.Map<BlogPostDto>(obj);
                return objDto;
            }
            catch { return new BlogPostDto(); }

        }

        public UpdateBlogPostDto UpdateBlogPost(UpdateBlogPostDto blogPostDto, int blogPostId)
        {
            var response = new UpdateBlogPostDto();
            try
            {
                if (blogPostDto == null || blogPostId != Convert.ToInt32(blogPostDto.Id))
                {
                    response.Message = "ID does not Match";
                    return response;
                }

                var blogPostObj = _mapper.Map<BlogPost>(blogPostDto);
                if (!_blogPostRepo.UpdateBlogPost(blogPostObj))
                {
                    response.Message = $"Somthing went wrong when updating the records {blogPostObj.Title}";
                    return response;
                }
                response.Message = "No content";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred: " + ex.Message;
                return response;
            }

        }
    }
}
