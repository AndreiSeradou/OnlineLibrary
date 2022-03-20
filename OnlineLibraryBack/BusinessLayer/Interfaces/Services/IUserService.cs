using BusinessLayer.Models.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> CreateOrderAsync(string userName, int BookId, CancellationToken ct = default);
        Task<IReadOnlyCollection<OrderBLModel>> GetAllUserOrdersAsync(string userName, CancellationToken ct = default);
        Task<IReadOnlyCollection<BookBLModel>> GetAllUserBooksAsync(string userName, CancellationToken ct = default);
        Task<IReadOnlyCollection<BookBLModel>> GetAllBooksAsync(CancellationToken ct = default);
        Task<IReadOnlyCollection<OrderBLModel>> GetOverdueOrdersAsync(string userName, CancellationToken ct = default);
    }
}
