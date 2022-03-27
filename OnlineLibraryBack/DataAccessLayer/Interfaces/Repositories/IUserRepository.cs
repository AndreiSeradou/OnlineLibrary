using DataAccessLayer.Models.DTOs;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntityModel> GetByIdIncludeAllAsync(string userId);
        Task<bool> UpdateAsync(UserEntityModel model);
        Task SaveAsync();
    }
}
