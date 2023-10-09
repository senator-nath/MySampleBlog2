using MySampleBlog2.Data;
using MySampleBlog2.Model;

namespace MySampleBlog2.Repository.CommentRepository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _db;
        public CommentRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CommentExists(string content)
        {
            {
                try
                {
                    bool value = _db.Comments.Any(a => a.Content.ToLower().Trim() == content.ToLower().Trim());
                    return value;
                }
                catch (Exception ex)
                {
                    throw new Exception("error", ex);
                }

            }
        }

        public bool CommentExists(int commentId)
        {
            try
            {
                return _db.Comments.Any(a => a.Id == commentId);
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }

        }

        public bool CreateComment(Comment comment)
        {

            {
                try
                {
                    _db.Comments.Add(comment);

                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to create comment", ex);
                }
                return Save();
            }
        }

        public bool DeleteComment(Comment comment)
        {
            try
            {
                _db.Comments.Remove(comment);
                return Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete comment", ex);
            }

        }

        public Comment GetComment(int commentId)
        {
            try
            {
                return _db.Comments.FirstOrDefault(a => a.Id == commentId);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get comment", ex);
            }

        }

        public ICollection<Comment> GetComments()
        {
            try
            {
                return _db.Comments.OrderBy(a => a.Content).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get comment", ex);
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
                throw new Exception("Failed to save comment", ex);
            }
        }

        public bool UpdateComment(Comment comment)
        {
            try
            {
                _db.Comments.Update(comment);
                return Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update comment", ex);
            }

        }
    }
}
