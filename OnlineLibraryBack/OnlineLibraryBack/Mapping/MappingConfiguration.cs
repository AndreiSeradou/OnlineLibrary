using AutoMapper;
using BusinessLayer.Models.DTOs;
using DataAccessLayer.Entities;
using OnlineLibraryBack.Models.DTOs.Requests;
using OnlineLibraryBack.Models.DTOs.Responses;

namespace OnlineLibraryPresentationLayer.Mapping
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
