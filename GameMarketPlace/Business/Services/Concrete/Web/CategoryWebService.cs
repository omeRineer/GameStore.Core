using AutoMapper;
using Business.Services.Abstract.Web;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Models.Category;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Concrete.Web
{
    public class CategoryWebService : ICategoryWebService
    {
        readonly IEfCategoryRepository _categoryRepository;
        readonly IMapper Mapper;

        public CategoryWebService(IEfCategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            Mapper = mapper;
        }

        public async Task<IDataResult<ListResponse<CategoryResponse>>> GetListAsync()
        {
            var data = await _categoryRepository.GetListAsync();

            var collection = Mapper.Map<List<CategoryResponse>>(data);

            var result = new ListResponse<CategoryResponse>(collection);

            return new SuccessDataResult<ListResponse<CategoryResponse>>(result);
        }
    }
}
