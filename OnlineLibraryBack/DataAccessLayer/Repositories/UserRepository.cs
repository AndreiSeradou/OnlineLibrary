using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(ApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<UserEntityModel> GetByIdAsync(string userId)
        {
            var user = await _dbContext.Users.Include(x => x.Orders).ThenInclude(x => x.Book).Include(x => x.Books)
                .FirstOrDefaultAsync(user => user.Id == userId);

            return _mapper.Map<UserEntityModel>(user);
        }

        public async Task<bool> UpdateAsync(UserEntityModel model)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(o => o.Id == model.Id);
            _mapper.Map<UserEntityModel, User>(model, entity);

            return entity != null;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
