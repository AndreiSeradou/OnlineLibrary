using AutoMapper;
using BusinessLayer.Models.DTOs.Responses;
using DataAccessLayer.Entities;

namespace BusinessLayer.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Book, BookResponse>().ReverseMap();
            CreateMap<Order, OrderResponse>().ReverseMap();
        }
    }
}
