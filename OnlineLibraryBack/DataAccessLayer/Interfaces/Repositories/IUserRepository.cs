using DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByNameIncludeAllAsync(string name);
        User Update(User model);
        Task SaveAsync();
    }
}
