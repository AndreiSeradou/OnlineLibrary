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
    public interface IBookRepository
    {
        Task<IReadOnlyCollection<Book>> GetAllAsync(CancellationToken ct = default);
        Task<Book> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Book> CreateAsync(Book model, CancellationToken ct = default);
        Task<Book> UpdateAsync(Book model, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task SaveAsync();
    }
}
