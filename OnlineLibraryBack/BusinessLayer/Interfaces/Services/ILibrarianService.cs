using BusinessLayer.Models.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.Services
{
    public interface ILibrarianService
    {
        Task<bool> UpdateOrderAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyCollection<OrderBLModel>> GetAllOrdersAsync(CancellationToken ct = default);
        Task<BookBLModel> CreateBookAsync(BookBLModel model, CancellationToken ct = default);
        Task<bool> DeleteOrderAsync(int id, CancellationToken ct = default);
    }
}
