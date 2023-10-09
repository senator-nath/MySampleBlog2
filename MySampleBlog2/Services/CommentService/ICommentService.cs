using MySampleBlog2.Model.ModelDto.CommentDto;

namespace MySampleBlog2.Services.CommentService
{
    public interface ICommentService
    {
        List<CommentGetDto> GetAll();
        CommentDto GetComment(int commentId);
        CreateCommentDto CreateComment(CreateCommentDto commentDto);
        UpdateCommentDto UpdateComment(UpdateCommentDto commentDto, int commentId);
        DeleteCommentDto DeleteComment(int commentId);
    }
}
