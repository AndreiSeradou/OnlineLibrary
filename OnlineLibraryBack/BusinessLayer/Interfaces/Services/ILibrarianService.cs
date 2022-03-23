using BusinessLayer.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.Services
{
    public interface ILibrarianService
    {
        Task<bool> UpdateOrderAsync(int id);
        Task<IReadOnlyCollection<OrderBLModel>> GetAllOrdersAsync();
        Task<BookBLModel> CreateBookAsync(BookBLModel model);
        Task<bool> DeleteOrderAsync(int id);
    }
}
