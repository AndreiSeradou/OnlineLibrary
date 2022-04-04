using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
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
                .AsNoTracking().ToListAsync();

            return _mapper.Map<IReadOnlyCollection<BookEntityModel>>(books);
        }

        public async Task<IReadOnlyCollection<BookEntityModel>> GetAsync(string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return await GetAllAsync();
            }

            Expression<Func<Book, object>> orderByExp;

            orderBy = orderBy.ToUpper(CultureInfo.CurrentCulture);

            if (orderBy == nameof(Book.Name).ToUpper())
            {
                orderByExp = entity => entity.Name;
            }
            else if (orderBy == nameof(Book.Text).ToUpper())
            {
                orderByExp = entity => entity.Text;
            }
            else if (orderBy == nameof(Book.Count).ToUpper())
            {
                orderByExp = entity => entity.Count;
            }
            else if (orderBy == nameof(Book.Id).ToUpper())
            {
                orderByExp = entity => entity.Id;
            }
            else
            {
                return await GetAllAsync();
            }

            var result = await _dbContext.Books.OrderBy(orderByExp).ToListAsync();

            return _mapper.Map<IReadOnlyCollection<BookEntityModel>>(result);
        }

        public async Task<BookEntityModel> GetByIdAsync(int bookId)
        {
            var entity = await _dbContext.Books
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
            var entity = await _dbContext.Books.FirstOrDefaultAsync(o => o.Id == model.Id);

            _mapper.Map<BookEntityModel, Book>(model, entity);

            return entity != null;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}