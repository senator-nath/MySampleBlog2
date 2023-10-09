namespace MySampleBlog2.Model.ModelDto.CommentDto
{
    public class UpdateCommentDto
    {
        public string Id { get; set; }
        public string Content { get; set; }

        public int BlogPostId { get; set; }

        public int UserId1 { get; set; }
        public string Message { get; set; }
    }
}
