using AutoMapper;
using VirtualGallery.Models;
using VirtualGallery.ViewModel;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorViewModel>();
        CreateMap<AuthorViewModel, Author>();

        CreateMap<Image, ImageViewModel>()
            .ForMember(dest => dest.AuthorID, opt => opt.MapFrom(src => src.Author.ID))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.Category.ID))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
        CreateMap<ImageViewModel, Image>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

        CreateMap<Category, CategoryViewModel>()
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));
        CreateMap<CategoryViewModel, Category>()
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));
    }
}
