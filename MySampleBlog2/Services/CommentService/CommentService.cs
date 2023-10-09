using AutoMapper;
using MySampleBlog2.Model;
using MySampleBlog2.Model.ModelDto.CommentDto;
using MySampleBlog2.Repository.CommentRepository;

namespace MySampleBlog2.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepo, IMapper mapper)
        {
            _commentRepo = commentRepo;
            _mapper = mapper;
        }
        public CreateCommentDto CreateComment(CreateCommentDto commentDto)
        {
            Console.WriteLine($"inside create Comment controller");
            var response = new CreateCommentDto();
            try
            {
                if (commentDto == null)
                {
                    return null;
                }
                if (_commentRepo.CommentExists(commentDto.Content))
                {

                    response.Message = "Category already exist";
                    return response;
                }

                // var nationalParkObj = _mapper.Map<NationalParks>(nationalParkDto);
                var com = new Comment
                {
                    Content = commentDto.Content,

                };
                var res = _commentRepo.CreateComment(com);
                if (res)
                {
                    response = new CreateCommentDto()
                    {
                        Content = commentDto.Content

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

        public DeleteCommentDto DeleteComment(int commentId)
        {
            var response = new DeleteCommentDto();
            try
            {
                if (!_commentRepo.CommentExists(commentId))
                {
                    response.Message = "Category does not exist";
                    return response;
                }

                var commentObj = _commentRepo.GetComment(commentId);
                if (!_commentRepo.DeleteComment(commentObj))
                {
                    response.Message = $"Somthing went wrong when deleting the records";

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

        public List<CommentGetDto> GetAll()
        {
            try
            {
                var objList = _commentRepo.GetComments();
                var objDto = new List<CommentGetDto>();

                foreach (var obj in objList)
                {
                    objDto.Add(_mapper.Map<CommentGetDto>(obj));
                }
                return objDto;
            }
            catch { return new List<CommentGetDto>(); }

        }

        public CommentDto GetComment(int commentId)
        {
            try
            {
                var resp = new CommentDto();
                var obj = _commentRepo.GetComment(commentId);
                if (obj == null)
                {
                    resp.Message = "Incorrect ID";
                    return resp;
                }
                var objDto = _mapper.Map<CommentDto>(obj);
                return objDto;
            }
            catch { return new CommentDto(); }
        }

        public UpdateCommentDto UpdateComment(UpdateCommentDto commentDto, int commentId)
        {
            var response = new UpdateCommentDto();
            try
            {
                if (commentDto == null || commentId != Convert.ToInt32(commentDto.Id))
                {
                    response.Message = "ID does not Match";
                    return response;
                }

                var commentObj = _mapper.Map<Comment>(commentDto);
                if (!_commentRepo.UpdateComment(commentObj))
                {
                    response.Message = $"Somthing went wrong when updating the records  ";
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
