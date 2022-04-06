using AutoMapper;
using OnlineLibrary.BusinessLayer.Models.DTOs;
using OnlineLibrary.DataAccessLayer.Entities;
using OnlineLibrary.PresentationLayer.Models.DTOs.Requests;
using OnlineLibrary.PresentationLayer.Models.DTOs.Responses;

namespace OnlineLibrary.PresentationLayer.Mapping
{
    public class MappingPLConfiguration : Profile
    {
        public MappingPLConfiguration()
        {
            CreateMap<OrderBLModel, OrderResponse>().ReverseMap();
            CreateMap<BookBLModel, BookResponse>().ReverseMap();
            CreateMap<BookBLModel, BookRequest>().ReverseMap();
            CreateMap<Book, BookResponse>().ReverseMap();
            CreateMap<UserResponse, User>().ReverseMap();
        }
    }
}
