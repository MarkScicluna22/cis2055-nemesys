using Microsoft.AspNetCore.Mvc;
using Nemesys.Models;
using Nemesys.Models.Domain;
using Nemesys.Models.ViewModels;
using Nemesys.Repositories;
using System.Diagnostics;

namespace Nemesys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReportRepository reportRepository;
		private readonly ITagRepository tagRepository;

		public HomeController(ILogger<HomeController> logger,
            IReportRepository reportRepository,
            ITagRepository tagRepository)
        {
            _logger = logger;
            this.reportRepository = reportRepository;
			this.tagRepository = tagRepository;
		}

        public async Task<IActionResult> Index()
        {
            //get all reports
            var reports = await reportRepository.GetAllWithStatusAsync();

            //get all tags
            var tags = await tagRepository.GetAllAsync();

            var model = new HomeViewModel
            {
                Reports = reports,
                Tags = tags,
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
