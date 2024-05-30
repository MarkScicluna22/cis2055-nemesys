using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Models.ViewModels;
using Nemesys.Repositories;

namespace Nemesys.Controllers
{

    [Authorize(Roles = "Investigator")]
    public class InvestigatorsUsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public InvestigatorsUsersController(IUserRepository userRepository) 
        { 
            this.userRepository = userRepository;
        }

        public async Task<IActionResult> List()
        {
            var users = await userRepository.GetAll();

            var usersViewModel = new UserViewModel();
            usersViewModel.Users = new List<User>();

            foreach (var user in users) 
            {
                usersViewModel.Users.Add(new Models.ViewModels.User
                {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName,
                    Email = user.Email
                });
            }
            return View(usersViewModel);
        }
    }
}
