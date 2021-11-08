using AutoMapper;
using Supermarket.Domain.Dtos.Carts;
using Supermarket.Domain.Dtos.Products;
using Supermarket.Domain.Dtos.Users;
using Supermarket.Domain.Entities;

namespace Supermarket.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDtoCreate, User>()
                .ReverseMap();

            CreateMap<UserDtoCreateResult, User>()
                .ReverseMap();

            CreateMap<UserDtoUpdateResult, User>()
                .ReverseMap();

            CreateMap<ProductDtoCreate, Product>()
                .ReverseMap();

            CreateMap<CartDtoCreate, Cart>()
                .ReverseMap();
        }
    }
}
