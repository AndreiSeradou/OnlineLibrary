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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(ApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<OrderEntityModel>> GetAllAsync(CancellationToken ct = default)
        {
            var orders = await _dbContext.Orders.Include(x => x.Book)
                .AsNoTracking()
                .ToListAsync(ct)
                .ConfigureAwait(false);
            return _mapper.Map<IReadOnlyCollection<OrderEntityModel>>(orders);
        }

        public async Task<OrderEntityModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var order = await _dbContext.Orders.Include(x => x.User).ThenInclude(x => x.Books).Include(x => x.Book)
                .FirstOrDefaultAsync(user => user.Id == id, ct);
            return _mapper.Map<OrderEntityModel>(order);
        }

        public async Task<OrderEntityModel> CreateAsync(OrderEntityModel entity, CancellationToken ct = default)
        {
            var order = _mapper.Map<Order>(entity);
            var entityEntry = await _dbContext.Orders.AddAsync(order, ct).ConfigureAwait(false);
            return _mapper.Map<OrderEntityModel>(entityEntry.Entity);
        }

        public OrderEntityModel Update(OrderEntityModel entity, CancellationToken ct = default)
        {
            var order = _mapper.Map<Order>(entity);
            var entityEntry = _dbContext.Orders.Update(order);
            return _mapper.Map<OrderEntityModel>(entityEntry.Entity);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(id, ct).ConfigureAwait(false);
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
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
