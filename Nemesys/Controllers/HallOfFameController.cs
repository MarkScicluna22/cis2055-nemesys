using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Models.ViewModels;
using Nemesys.Repositories;

namespace Nemesys.Controllers
{
	public class HallOfFameController : Controller
	{
		private readonly IReportRepository reportRepository;
        private readonly UserManager<IdentityUser> userManager;

        public HallOfFameController(IReportRepository reportRepository,
            UserManager<IdentityUser> userManager)
		{
			this.reportRepository = reportRepository;
            this.userManager = userManager;
        }

		public async Task<IActionResult> Index()
		{
			var currentYear = DateTime.Now.Year;
			var topReporters = await reportRepository.GetTopReportersAsync(currentYear);
			//var Username = (await userManager.FindByIdAsync(topReporters.Username.ToString())).UserName;


            var viewModel = new HallOfFameViewModel
			{
				TopReporters = topReporters.ToList()
			};

			return View(viewModel);
		}
	}
}
