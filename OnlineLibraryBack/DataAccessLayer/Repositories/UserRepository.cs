using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<User> userManager, ApiDbContext dbContext, IMapper mapper)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<User> GetByNameIncludeAllAsync(string name, CancellationToken ct = default)
        {
            var user = await _dbContext.Users.Include(x => x.Orders).ThenInclude(x => x.Book).Include(x => x.Books)
                .FirstOrDefaultAsync(user => user.UserName == name, ct).ConfigureAwait(false);
            return user;
        }

        public async Task<User> GetByNameIncludeOrdersAsync(string name, CancellationToken ct = default)
        {
            var user = await _dbContext.Users.Include(x => x.Orders)
                 .FirstOrDefaultAsync(user => user.UserName == name, ct).ConfigureAwait(false);
            return user;
        }

        public async Task<IdentityResult> UpdateAsync(User model, CancellationToken ct = default)
        {
            return await _userManager.UpdateAsync(model).ConfigureAwait(false);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
