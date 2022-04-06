using OnlineLibrary.DataAccessLayer.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLibrary.DataAccessLayer.Interfaces.Repositories
{
    public interface IBookRepository
    {

        Task<IReadOnlyCollection<BookEntityModel>> GetAllAsync();
        Task<BookEntityModel> GetByIdAsync(int bookId);
        Task<bool> CreateAsync(BookEntityModel model);
        Task<bool> UpdateAsync(BookEntityModel orderId);
        Task<IReadOnlyCollection<BookEntityModel>> GetAsync(string orderBy);
        Task SaveAsync();
    }
}
