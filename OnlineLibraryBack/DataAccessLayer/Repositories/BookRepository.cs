using AutoMapper;
using OnlineLibrary.DataAccessLayer.Data;
using OnlineLibrary.DataAccessLayer.Entities;
using OnlineLibrary.DataAccessLayer.Interfaces.Repositories;
using OnlineLibrary.DataAccessLayer.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnlineLibrary.Configuration.GeneralConfiguration;

namespace OnlineLibrary.DataAccessLayer.Repositories
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
            var books = await _dbContext.Books.AsNoTracking().ToListAsync();

            return _mapper.Map<IReadOnlyCollection<BookEntityModel>>(books);
        }

        public async Task<IReadOnlyCollection<BookEntityModel>> GetAsync(string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return await GetAllAsync();
            }

            Expression<Func<Book, object>> orderByExp;
            var name = nameof(Book.Name).ToUpper();

            orderBy = orderBy.ToUpper(CultureInfo.CurrentCulture);

            switch (orderBy)
            {
                case GeneralConfiguration.NameOfBookId:
                    orderByExp = entity => entity.Id;
                    break;
                case GeneralConfiguration.NameOfBookName:
                    orderByExp = entity => entity.Name;
                    break;
                case GeneralConfiguration.NameOfBookCount:
                    orderByExp = entity => entity.Count;
                    break;
                case GeneralConfiguration.NameOfBookText:
                    orderByExp = entity => entity.Text;
                    break;
                default:
                    return await GetAllAsync();
            }

            var result = await _dbContext.Books.OrderBy(orderByExp).ToListAsync();

            return _mapper.Map<IReadOnlyCollection<BookEntityModel>>(result);
        }

        public async Task<BookEntityModel> GetByIdAsync(int bookId)
        {
            var entity = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);

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