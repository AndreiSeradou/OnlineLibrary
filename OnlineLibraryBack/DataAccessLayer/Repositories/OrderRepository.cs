using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApiDbContext _dbContext;

        public OrderRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.Orders.Include(x => x.Book)
                .AsNoTracking()
                .ToListAsync(ct)
                .ConfigureAwait(false);
        }

        public  Task<Order?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return  _dbContext.Orders.Include(x => x.User).ThenInclude(x => x.Books).Include(x => x.Book)
                .FirstOrDefaultAsync(user => user.Id == id, ct)!;
        }

        public async Task<Order> CreateAsync(Order entity, CancellationToken ct = default)
        {
            var entityEntry = await _dbContext.Orders.AddAsync(entity, ct).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }

        public async Task<Order> UpdateAsync(Order entity, CancellationToken ct = default)
        {
            var entityEntry = _dbContext.Orders.Update(entity);
            await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(id, ct).ConfigureAwait(false);
            if (entity != null)
            {
                var entityEntry = _dbContext.Orders.Remove(entity);
                await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
                return entityEntry != null;
            }

            return false;
        }
    }
}
