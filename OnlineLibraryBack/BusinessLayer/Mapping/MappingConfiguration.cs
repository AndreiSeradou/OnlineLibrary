using AutoMapper;
using OnlineLibrary.BusinessLayer.Models.DTOs;
using OnlineLibrary.DataAccessLayer.Entities;
using OnlineLibrary.DataAccessLayer.Models.DTOs;

namespace OnlineLibrary.BusinessLayer.Mapping
{
    public class MappingBLConfiguration : Profile
    {
        public MappingBLConfiguration()
        {
            CreateMap<BookEntityModel, BookBLModel>().ReverseMap();
            CreateMap<OrderEntityModel, OrderBLModel>().ReverseMap();
            CreateMap<UserEntityModel, UserBLModel>().ReverseMap();
            CreateMap<BookEntityModel, Book>().ReverseMap();
            CreateMap<OrderEntityModel, Order>().ReverseMap();
            CreateMap<UserEntityModel, User>().ReverseMap();
            CreateMap<Book, BookBLModel>().ReverseMap();
            CreateMap<Order, OrderBLModel>().ReverseMap();
            CreateMap<User, UserBLModel>().ReverseMap();
        }
    }
}
