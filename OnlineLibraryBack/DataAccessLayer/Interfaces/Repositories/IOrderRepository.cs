using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IReadOnlyCollection<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<Order> CreateAsync(Order model);
        Order Update(Order model);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
