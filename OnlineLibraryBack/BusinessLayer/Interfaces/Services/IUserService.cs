using BusinessLayer.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> CreateOrderAsync(string userName, int BookId);
        Task<IReadOnlyCollection<OrderBLModel>> GetAllUserOrdersAsync(string userName);
        Task<IReadOnlyCollection<BookBLModel>> GetAllUserBooksAsync(string userName);
        Task<IReadOnlyCollection<BookBLModel>> GetAllBooksAsync(string orderBy = default);
        Task<IReadOnlyCollection<BookBLModel>> GetFilteredBooksAsync(string filterBy);
        Task<IReadOnlyCollection<OrderBLModel>> GetOverdueOrdersAsync(string userName);
    }
}
