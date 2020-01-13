using AutoMapper;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
