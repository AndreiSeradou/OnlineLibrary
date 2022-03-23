using DataAccessLayer.Entities;
using DataAccessLayer.Models.DTOs;
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
        Task<IReadOnlyCollection<OrderEntityModel>> GetAllAsync(CancellationToken ct = default);
        Task<OrderEntityModel> GetByIdAsync(int id, CancellationToken ct = default);
        Task<OrderEntityModel> CreateAsync(OrderEntityModel model, CancellationToken ct = default);
        OrderEntityModel Update(OrderEntityModel model, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task SaveAsync();
    }
}
