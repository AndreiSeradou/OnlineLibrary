using BusinessLayer.Models.DTOs.Responses;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.Services
{
    public interface ILibrarianService
    {
        Task<bool?> UpdateOrderAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyCollection<OrderResponse>> GetAllOrdersAsync(CancellationToken ct = default);
        Task<BookResponse> CreateBookAsync(Book model, CancellationToken ct = default);
    }
}
