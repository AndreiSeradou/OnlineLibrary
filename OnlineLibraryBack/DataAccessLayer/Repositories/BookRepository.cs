using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookRepository(ApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<Book>> GetAllAsync(CancellationToken ct = default)
        {
            var books = await _dbContext.Books
                .AsNoTracking()
                .ToListAsync(ct)
                .ConfigureAwait(false);

            return books;
        }

        public async Task<Book> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(user => user.Id == id, ct);
            return book;
        }

        public async Task<Book> CreateAsync(Book entity, CancellationToken ct = default)
        {
            var entityEntry = await _dbContext.Books.AddAsync(entity, ct).ConfigureAwait(false);

            return entityEntry.Entity;
        }

        public async Task<Book> UpdateAsync(Book entity, CancellationToken ct = default)
        {
            var entityEntry = _dbContext.Books.Update(entity);
            return entityEntry.Entity;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(id, ct).ConfigureAwait(false);
            var book = _mapper.Map<Book>(entity);
            if (entity != null)
            {
                var entityEntry = _dbContext.Books.Remove(book);

                return entityEntry != null;
            }

            return false;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}