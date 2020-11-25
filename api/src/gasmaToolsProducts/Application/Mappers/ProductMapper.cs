using AutoMapper;
using gasmaToolsProducts.Application.ViewModels;
using gasmaToolsProducts.Domain.Commands.Product;
using gasmaToolsProducts.Domain.Models;

namespace gasmaToolsProducts.Application.Mappers
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>().ReverseMap();

            CreateMap<Product, ProductViewModel>();
        }
    }
}
