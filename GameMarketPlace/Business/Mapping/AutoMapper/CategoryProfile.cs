using AutoMapper;
using Entities.Main;
using Models.Category.WebService;
using Models.Game.WebService;

namespace Business.Mapping.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            #region Rest
            CreateMap<Category, SingleCategoryResponse>().ReverseMap();
            CreateMap<Category, SingleGame_Category>().ReverseMap();
            CreateMap<CreateCategoryRequest, Category>().ReverseMap();
            CreateMap<UpdateCategoryRequest, Category>().ReverseMap();
            #endregion

        }
    }
}
