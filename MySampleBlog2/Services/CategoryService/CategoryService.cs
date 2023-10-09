using AutoMapper;
using MySampleBlog2.Model;
using MySampleBlog2.Model.ModelDto.CategoryDtos;
using MySampleBlog2.Repository.CategoryRepository;

namespace MySampleBlog2.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepo;
        public CategoryService(IMapper mapper, ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public CreateCategoryDto CreateCategory(CreateCategoryDto categoryDto)
        {
            Console.WriteLine($"inside create Category controller");
            var response = new CreateCategoryDto();
            try
            {
                if (categoryDto == null)
                {
                    return null;
                }
                if (_categoryRepo.CategoryExists(categoryDto.Name))
                {

                    response.Message = "Category already exist";
                    return response;
                }

                // var nationalParkObj = _mapper.Map<NationalParks>(nationalParkDto);
                var cat = new Category
                {
                    Name = categoryDto.Name,

                };
                var res = _categoryRepo.CreateCategory(cat);
                if (res)
                {
                    response = new CreateCategoryDto()
                    {
                        Name = categoryDto.Name

                    };
                    return response;
                }
                response.Message = "an error has occurred";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred: " + ex.Message;
                return response;

            }

        }

        public DeleteCategoryDto DeleteCategory(int categoryId)
        {
            var response = new DeleteCategoryDto();
            try
            {
                if (!_categoryRepo.CategoryExists(categoryId))
                {
                    response.Message = "Category does not exist";
                    return response;
                }

                var categoryObj = _categoryRepo.GetCategory(categoryId);
                if (!_categoryRepo.DeleteCategory(categoryObj))
                {
                    response.Message = $"Something went wrong when deleting the records {categoryObj.Name}";

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

        public List<CategoryGetDto> GetAll()
        {
            try
            {
                var objList = _categoryRepo.GetCategories();
                var objDto = new List<CategoryGetDto>();

                foreach (var obj in objList)
                {
                    objDto.Add(_mapper.Map<CategoryGetDto>(obj));
                }
                return objDto;
            }
            catch { return new List<CategoryGetDto>(); }
        }

        public CategoryDto GetCategory(int categoryId)
        {
            var resp = new CategoryDto();
            try
            {
                var obj = _categoryRepo.GetCategory(categoryId);
                if (obj == null)
                {
                    resp.Message = "Incorrect ID";
                    return resp;
                }
                var objDto = _mapper.Map<CategoryDto>(obj);
                return objDto;
            }
            catch { return new CategoryDto(); }
        }

        public UpdateCategoryDto UpdateCategory(CategoryDto categoryDto, int CategoryId)
        {
            var response = new UpdateCategoryDto();
            try
            {
                if (categoryDto == null || CategoryId != categoryDto.Id)
                {
                    response.Message = "ID does not Match";
                    return response;
                }

                var categoryObj = _mapper.Map<Category>(categoryDto);
                if (!_categoryRepo.UpdateCategory(categoryObj))
                {
                    response.Message = $"Something went wrong when updating the records {categoryObj.Name}";
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
