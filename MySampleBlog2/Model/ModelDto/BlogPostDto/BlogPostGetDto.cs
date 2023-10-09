namespace MySampleBlog2.Model.ModelDto.BlogPostDto
{
    public class BlogPostGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Message { get; set; }

        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
