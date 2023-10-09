namespace MySampleBlog2.Model.ModelDto.CommentDto
{
    public class CommentGetDto
    {

        public string Content { get; set; }

        public int BlogPostId { get; set; }

        public int UserId1 { get; set; }
        public string Message { get; set; }
    }
}
