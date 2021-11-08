using AutoMapper;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Models;

namespace Supermarket.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<User, UserModel>()
                .ReverseMap();
        }
    }
}
