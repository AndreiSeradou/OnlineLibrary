using OnlineLibrary.DataAccessLayer.Models.DTOs;
using System.Threading.Tasks;

namespace OnlineLibrary.DataAccessLayer.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntityModel> GetByIdAsync(string userId);
        Task<bool> UpdateAsync(UserEntityModel model);
        Task SaveAsync();
    }
}
