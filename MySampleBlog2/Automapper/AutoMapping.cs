using AutoMapper;
using MySampleBlog2.Model;
using MySampleBlog2.Model.ModelDto.BlogPostDto;
using MySampleBlog2.Model.ModelDto.CategoryDtos;
using MySampleBlog2.Model.ModelDto.CommentDto;

namespace MySampleBlog2.Automapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, DeleteCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryGetDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            CreateMap<Comment, DeleteCommentDto>().ReverseMap();
            CreateMap<Comment, CommentGetDto>().ReverseMap();
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
            CreateMap<BlogPost, BlogPostGetDto>().ReverseMap();
            CreateMap<BlogPost, CreateBlogPostDto>().ReverseMap();
            CreateMap<BlogPost, UpdateBlogPostDto>().ReverseMap();
            CreateMap<BlogPost, DeleteBlogPostDto>().ReverseMap();
        }
    }
}
