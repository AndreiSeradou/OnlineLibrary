using BusinessLayer.Models.DTOs.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> CreateOrderAsync(string userName, int BookId, CancellationToken ct = default);
        Task<IReadOnlyCollection<OrderResponse>> GetAllUserOrdersAsync(string userName, CancellationToken ct = default);
        Task<IReadOnlyCollection<BookResponse>> GetAllUserBooksAsync(string userName, CancellationToken ct = default);
        Task<IReadOnlyCollection<BookResponse>> GetAllBooksAsync(CancellationToken ct = default);
    }
}
