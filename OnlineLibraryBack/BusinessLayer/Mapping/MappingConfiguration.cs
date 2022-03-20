using AutoMapper;
using BusinessLayer.Models.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Models.DTOs;

namespace BusinessLayer.Mapping
{
    public class MappingBLConfiguration : Profile
    {
        public MappingBLConfiguration()
        {
            CreateMap<BookEntityModel, BookBLModel>().ReverseMap();
            CreateMap<OrderEntityModel, OrderBLModel>().ReverseMap();
            CreateMap<UserEntityModel, UserBLModel>().ReverseMap();
            CreateMap<Book, BookBLModel>().ReverseMap();
            CreateMap<Order, OrderBLModel>().ReverseMap();
            CreateMap<User, UserBLModel>().ReverseMap();
        }
    }
}
