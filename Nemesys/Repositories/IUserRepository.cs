using Microsoft.AspNetCore.Identity;

namespace Nemesys.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
