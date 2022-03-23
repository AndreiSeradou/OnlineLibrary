using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<IReadOnlyCollection<Order>> GetAllAsync()
        {
            var orders = await _dbContext.Orders.Include(x => x.Book)
                .AsNoTracking()
                .ToListAsync();
            return orders;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _dbContext.Orders.Include(x => x.User).ThenInclude(x => x.Books).Include(x => x.Book)
                .FirstOrDefaultAsync(user => user.Id == id).co;
            return order;
        }

        public async Task<Order> CreateAsync(Order entity)
        {
            var entityEntry = await _dbContext.Orders.AddAsync(entity);
           
            return entityEntry.Entity;
        }

        public Order Update(Order entity)
        {
            var entityEntry = _dbContext.Orders.Update(entity);

            return entityEntry.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            var order = _mapper.Map<Order>(entity);
            if (entity != null)
            {
                var entityEntry = _dbContext.Orders.Remove(order);
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
