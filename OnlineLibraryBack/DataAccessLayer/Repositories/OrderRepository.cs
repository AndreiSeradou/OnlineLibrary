using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(ApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<IReadOnlyCollection<OrderEntityModel>> GetAllAsync()
        {
            var orders = await _dbContext.Orders.Include(x => x.Book).Include(u => u.User)
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<IReadOnlyCollection<OrderEntityModel>>(orders);
        }

        public async Task<bool> CreateAsync(string userId, int bookId)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);
            var user = await _dbContext.Users.Include(x => x.Orders).ThenInclude(x => x.Book).FirstOrDefaultAsync(u => u.Id == userId);
            var userOrder = user.Orders.FirstOrDefault(o => o.Book.Name == book.Name);

            if (userOrder != null || book.Count <= 0)
            {
                return false;
            }

            book.Count--;
            var order = new Order { BookId = bookId, UserId = userId };
            var entityEntry = await _dbContext.Orders.AddAsync(order);

            if (entityEntry is null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateAsync(int orderId)
        {
            var entity = await _dbContext.Orders.Include(x => x.User).ThenInclude(x => x.Books).Include(x => x.Book).FirstOrDefaultAsync(o => o.Id == orderId);

            if (entity is null)
            {
                return false;
            }

            entity.Condition = true;
            entity.DateTimeCreated = DateTime.UtcNow;
            entity.User.Books.Add(entity.Book);

            return true;
        }

        public async Task<bool> DeleteAsync(int orderId)
        {
            var entity = await _dbContext.Orders.Include(x => x.User).ThenInclude(x => x.Books).Include(x => x.Book).FirstOrDefaultAsync(b => b.Id == orderId);
            entity.Book.Count++;
            entity.User.Books.Remove(entity.Book);

            if (entity != null)
            {
                var entityEntry = _dbContext.Orders.Remove(entity);
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
