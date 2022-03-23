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
        Task<IReadOnlyCollection<BookEntityModel>> GetAllAsync(CancellationToken ct = default);
        Task<BookEntityModel> GetByIdAsync(int id, CancellationToken ct = default);
        Task<BookEntityModel> CreateAsync(BookEntityModel model, CancellationToken ct = default);
        BookEntityModel Update(BookEntityModel model, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task SaveAsync();
    }
}
