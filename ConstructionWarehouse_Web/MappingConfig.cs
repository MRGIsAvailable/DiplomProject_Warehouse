using AutoMapper;
using ConstructionWarehouse_Web.Models.Dto;

namespace ConstructionWarehouse_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ProductDTO, ProductCreateDTO>().ReverseMap();
            CreateMap<ProductDTO, ProductUpdateDTO>().ReverseMap();

            CreateMap<OrderDTO, OrderCreateDTO>().ReverseMap();
            CreateMap<OrderDTO, OrderUpdateDTO>().ReverseMap();

            CreateMap<CategoryDTO, CategoryCreateDTO>().ReverseMap();
            CreateMap<CategoryDTO, CategoryUpdateDTO>().ReverseMap();

            CreateMap<InventoryDTO, InventoryCreateDTO>().ReverseMap();
            CreateMap<InventoryDTO, InventoryUpdateDTO>().ReverseMap();

            CreateMap<SupplierDTO, SupplierCreateDTO>().ReverseMap();
            CreateMap<SupplierDTO, SupplierUpdateDTO>().ReverseMap();

            CreateMap<SupplierProductDTO, SupplierProductCreateDTO>().ReverseMap();
            CreateMap<SupplierProductDTO, SupplierProductUpdateDTO>().ReverseMap();

            CreateMap<StatusDTO, StatusCreateDTO>().ReverseMap();
            CreateMap<StatusDTO, StatusUpdateDTO>().ReverseMap();

            CreateMap<UserDTO, UserCreateDTO>().ReverseMap();
            CreateMap<UserDTO, UserUpdateDTO>().ReverseMap();

            CreateMap<PremiseDTO, PremiseCreateDTO>().ReverseMap();
            CreateMap<PremiseDTO, PremiseUpdateDTO>().ReverseMap();
        }
    }
}
