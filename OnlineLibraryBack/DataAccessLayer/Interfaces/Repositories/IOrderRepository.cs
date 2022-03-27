using DataAccessLayer.Entities;
using DataAccessLayer.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IOrderRepository
    {

        Task<IReadOnlyCollection<OrderEntityModel>> GetAllAsync();
        Task<OrderEntityModel> GetByIdIncludeAllAsync(int orderId);
        Task<bool> CreateAsync(string userId, int bookId);
        Task<bool> UpdateAsync(OrderEntityModel model);
        Task<bool> DeleteAsync(int orderId);
        Task SaveAsync();
    }
}
