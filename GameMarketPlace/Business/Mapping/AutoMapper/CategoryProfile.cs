using AutoMapper;
using Entities.Main;
using Models.Category;
using Models.Game;

namespace Business.Mapping.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            #region Rest
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<CreateCategoryRequest, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequest, Category>().ReverseMap();
            #endregion

        }
    }
}
