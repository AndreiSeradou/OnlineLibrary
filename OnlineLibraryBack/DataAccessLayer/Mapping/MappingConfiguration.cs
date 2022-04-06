using AutoMapper;
using OnlineLibrary.DataAccessLayer.Entities;
using OnlineLibrary.DataAccessLayer.Models.DTOs;

namespace OnlineLibrary.DataAccessLayer.Mapping
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
