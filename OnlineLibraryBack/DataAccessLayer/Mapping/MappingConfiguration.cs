using System;
using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Models.DTOs;

namespace DataAccessLayer.Mapping
{
    public class MappingDLConfiguration : Profile
    {
        public MappingDLConfiguration()
        {
            CreateMap<Book, BookEntityModel>().ReverseMap();
            CreateMap<Order, OrderEntityModel>().ReverseMap();
            CreateMap<User, UserEntityModel>().ReverseMap();
        }
    }
}
