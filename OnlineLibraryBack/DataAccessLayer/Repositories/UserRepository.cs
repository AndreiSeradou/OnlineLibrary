using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
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
        private readonly ApiDbContext  _apiDbContext;

        public UserRepository(UserManager<User> userManager, ApiDbContext apiDbContext)
        {
            _userManager = userManager;
            _apiDbContext = apiDbContext;
        }

        public async Task<User?> GetByNameIncludeAllAsync(string name, CancellationToken ct = default)
        {
            return await _userManager.Users.Include(x => x.Orders).ThenInclude(x => x.Book).Include(x => x.Books)
                .FirstOrDefaultAsync(user => user.UserName == name, ct).ConfigureAwait(false)!;
        }

        public async Task<User?> GetByNameIncludeOrdersAsync(string name, CancellationToken ct = default)
        {
            return await _userManager.Users.Include(x => x.Orders)
                 .FirstOrDefaultAsync(user => user.UserName == name, ct).ConfigureAwait(false)!;
        }

        public async Task<IdentityResult> UpdateAsync(User model, CancellationToken ct = default)
        {
            return await _userManager.UpdateAsync(model).ConfigureAwait(false);
        }
    }
}
