using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
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

        public async Task<User> GetByNameIncludeAllAsync(string name)
        {
            var user = await _dbContext.Users.Include(x => x.Orders).ThenInclude(x => x.Book).Include(x => x.Books)
                .FirstOrDefaultAsync(user => user.UserName == name);
            return user;
        }

        public User Update(User model)
        {
            var entityEntry = _dbContext.Users.Update(model);
            return entityEntry.Entity;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
