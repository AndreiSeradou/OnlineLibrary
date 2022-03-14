using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken ct = default);
        Task<Order?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Order> CreateAsync(Order model, CancellationToken ct = default);
        Task<Order> UpdateAsync(Order model, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
