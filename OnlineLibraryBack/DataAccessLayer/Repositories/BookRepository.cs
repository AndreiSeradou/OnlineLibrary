using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApiDbContext _dbContext;

        public BookRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<Book>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.Books
                .AsNoTracking()
                .ToListAsync(ct)
                .ConfigureAwait(false);
        }

        public Task<Book?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _dbContext.Books.AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id, ct)!;
        }

        public async Task<Book> CreateAsync(Book entity, CancellationToken ct = default)
        {
            var entityEntry = await _dbContext.Books.AddAsync(entity, ct).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }

        public async Task<Book> UpdateAsync(Book entity, CancellationToken ct = default)
        {
            var entityEntry = _dbContext.Books.Update(entity);
            await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(id, ct).ConfigureAwait(false);
            if (entity != null)
            {
                var entityEntry = _dbContext.Books.Remove(entity);
                await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
                return entityEntry != null;
            }

            return false;
        }
    }
}
