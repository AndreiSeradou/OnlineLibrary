using OnlineLibrary.DataAccessLayer.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLibrary.DataAccessLayer.Interfaces.Repositories
{
    public interface IOrderRepository
    {

        Task<IReadOnlyCollection<OrderEntityModel>> GetAllAsync();
        Task<OrderEntityModel> GetByIdAsync(int orderId);
        Task<OrderEntityModel> GetByUserIdBookIdAsync(string userId, int bookId);
        Task<bool> CreateAsync(string userId, int bookId);
        Task<bool> UpdateAsync(OrderEntityModel model);
        Task<bool> DeleteAsync(int orderId);
        Task SaveAsync();
    }
}
