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

        public async Task<IReadOnlyCollection<BookEntityModel>> GetAllAsync(CancellationToken ct = default)
        {
            var books = await _dbContext.Books
                .AsNoTracking()
                .ToListAsync(ct)
                .ConfigureAwait(false);

            return _mapper.Map<IReadOnlyCollection<BookEntityModel>>(books);
        }

        public async Task<BookEntityModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(user => user.Id == id, ct);
            _dbContext.Entry(book).State = EntityState.Modified;
            return _mapper.Map<BookEntityModel>(book);
        }

        public async Task<BookEntityModel> CreateAsync(BookEntityModel entity, CancellationToken ct = default)
        {
            var book = _mapper.Map<Book>(entity);
            var entityEntry = await _dbContext.Books.AddAsync(book, ct).ConfigureAwait(false);

            return _mapper.Map<BookEntityModel>(entityEntry.Entity);
        }

        public BookEntityModel Update(BookEntityModel entity, CancellationToken ct = default)
        {
            var book = _mapper.Map<Book>(entity);
            var entityEntry = _dbContext.Books.Update(book);
            return _mapper.Map<BookEntityModel>(entityEntry.Entity);
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