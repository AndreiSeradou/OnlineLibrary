using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByNameIncludeAllAsync(string name, CancellationToken ct = default);
        Task<User?> GetByNameIncludeOrdersAsync(string name, CancellationToken ct = default);
        Task<IdentityResult> UpdateAsync(User model, CancellationToken ct = default);
    }
}
