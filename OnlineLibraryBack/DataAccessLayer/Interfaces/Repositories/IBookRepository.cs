using DataAccessLayer.Entities;
using DataAccessLayer.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IBookRepository
    {

        Task<IReadOnlyCollection<BookEntityModel>> GetAllAsync();
        Task<BookEntityModel> GetByIdAsync(int bookId);
        Task<bool> CreateAsync(BookEntityModel model);
        Task<bool> UpdateAsync(BookEntityModel orderId);
        Task SaveAsync();
    }
}
