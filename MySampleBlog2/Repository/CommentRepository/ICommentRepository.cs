using MySampleBlog2.Model;

namespace MySampleBlog2.Repository.CommentRepository
{
    public interface ICommentRepository
    {
        ICollection<Comment> GetComments();

        bool CommentExists(string content);
        bool CommentExists(int commentId);
        bool CreateComment(Comment comment);
        bool UpdateComment(Comment comment);
        Comment GetComment(int commentId);
        bool DeleteComment(Comment comment);
        bool Save();
    }
}
