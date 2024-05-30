using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nemesys.Data;

namespace Nemesys.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NemesysDbContext nemesysDbContext;
        public UserRepository(NemesysDbContext nemesysDbContext)
        {
                this.nemesysDbContext = nemesysDbContext;
        }

        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            var users= await nemesysDbContext.Users.ToListAsync();

            var superInvestigatorUser = await nemesysDbContext.Users.
                FirstOrDefaultAsync(x => x.Email == "superinvestigator@gmail.com");

            if (superInvestigatorUser != null)
            {
                users.Remove(superInvestigatorUser);

            }

            return users;
        }
    }
}
