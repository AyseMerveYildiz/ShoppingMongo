using AutoMapper;
using ShoppingMongo.Dtos.CategoryDtos;
using ShoppingMongo.Dtos.ProductImageDtos;
using ShoppingMongo.Dtos.SliderDtos;
using ShoppingMongo.Entities;
using ShoppingMongo.Dtos.CategoryDtos;
using ShoppingMongo.Dtos.ProductDtos;

namespace ShoppingMongo.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();

            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, GetSliderDto>().ReverseMap();

            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetProductImageDto>().ReverseMap();
        }
    }
}
