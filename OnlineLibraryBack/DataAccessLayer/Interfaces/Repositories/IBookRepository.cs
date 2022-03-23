using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<IReadOnlyCollection<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> CreateAsync(Book model);
        Book Update(Book model);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
