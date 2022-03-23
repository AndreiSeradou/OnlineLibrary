using DataAccessLayer.Entities;
using DataAccessLayer.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntityModel> GetByNameIncludeAllAsync(string name, CancellationToken ct = default);
        UserEntityModel Update(UserEntityModel model, CancellationToken ct = default);
        Task SaveAsync();
    }
}
