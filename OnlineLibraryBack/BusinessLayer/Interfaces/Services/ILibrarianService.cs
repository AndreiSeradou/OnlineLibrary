using BusinessLayer.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.Services
{
    public interface ILibrarianService
    {
        Task<bool> UpdateOrderAsync(int id);
        Task<IReadOnlyCollection<OrderBLModel>> GetAllOrdersConditionFalseAsync();
        Task<IReadOnlyCollection<OrderBLModel>> GetAllOrdersConditionTrueAsync();
        Task<bool> CreateBookAsync(BookBLModel model);
        Task<bool> DeleteOrderAsync(int id);
    }
}
