using DataAccessLayer.Entities;
using DataAccessLayer.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByNameIncludeAllAsync(string name, CancellationToken ct = default);
        Task<User> GetByNameIncludeOrdersAsync(string name, CancellationToken ct = default);
        Task<IdentityResult> UpdateAsync(User model, CancellationToken ct = default);
        Task SaveAsync();
    }
}
