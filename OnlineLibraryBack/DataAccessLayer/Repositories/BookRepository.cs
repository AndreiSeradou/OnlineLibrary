using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<IReadOnlyCollection<Book>> GetAllAsync()
        {
            var books = await _dbContext.Books
                .AsNoTracking()
                .ToListAsync();

            return books;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(user => user.Id == id);
            return book;
        }

        public async Task<Book> CreateAsync(Book entity)
        {
            var entityEntry = await _dbContext.Books.AddAsync(entity);

            return entityEntry.Entity;
        }

        public Book Update(Book entity)
        {
            var entityEntry = _dbContext.Books.Update(entity);
            return entityEntry.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
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
            await _dbContext.SaveChangesAsync();
        }
    }
}