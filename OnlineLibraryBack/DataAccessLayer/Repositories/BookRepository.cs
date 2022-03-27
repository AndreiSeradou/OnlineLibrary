using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Models.DTOs;
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


        public async Task<IReadOnlyCollection<BookEntityModel>> GetAllAsync()
        {
            var books = await _dbContext.Books
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IReadOnlyCollection<BookEntityModel>>(books);
        }

        public async Task<BookEntityModel> GetByIdIncludeAllAsync(int bookId)
        {
            var entity = await _dbContext.Books.Include(x => x.Users).ThenInclude(x => x.Orders)
                .FirstOrDefaultAsync(b => b.Id == bookId);
            return _mapper.Map<BookEntityModel>(entity);
        }

        public async Task<bool> CreateAsync(BookEntityModel model)
        {
            var entity = _mapper.Map<Book>(model);
            var entityEntry = await _dbContext.Books.AddAsync(entity);

            return entityEntry.Entity != null;
        }

        public async Task<bool> UpdateAsync(BookEntityModel model)
        {
            var entity = await _dbContext.Books.Include(x => x.Users).ThenInclude(x => x.Orders).FirstOrDefaultAsync(o => o.Id == model.Id);

            _mapper.Map<BookEntityModel, Book>(model, entity);

            return entity != null;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}