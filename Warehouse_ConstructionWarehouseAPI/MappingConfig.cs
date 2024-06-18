using AutoMapper;
using Warehouse_ConstructionWarehouseAPI.Models;
using Warehouse_ConstructionWarehouseAPI.Models.Dto;

namespace Warehouse_ConstructionWarehouseAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderCreateDTO>().ReverseMap();
            CreateMap<Order, OrderUpdateDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();

            CreateMap<Inventory, InventoryDTO>().ReverseMap();
            CreateMap<Inventory, InventoryCreateDTO>().ReverseMap();
            CreateMap<Inventory, InventoryUpdateDTO>().ReverseMap();

            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<Supplier, SupplierCreateDTO>().ReverseMap();
            CreateMap<Supplier, SupplierUpdateDTO>().ReverseMap();

            CreateMap<SupplierProduct, SupplierProductDTO>().ReverseMap();
            CreateMap<SupplierProduct, SupplierProductCreateDTO>().ReverseMap();
            CreateMap<SupplierProduct, SupplierProductUpdateDTO>().ReverseMap();

            CreateMap<Status, StatusDTO>().ReverseMap();
            CreateMap<Status, StatusCreateDTO>().ReverseMap();
            CreateMap<Status, StatusUpdateDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();

            CreateMap<Premise, PremiseDTO>().ReverseMap();
            CreateMap<Premise, PremiseCreateDTO>().ReverseMap();
            CreateMap<Premise, PremiseUpdateDTO>().ReverseMap();
        }
    }
}
