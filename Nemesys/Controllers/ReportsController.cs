using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Nemesys.Models.Domain;
using Nemesys.Models.ViewModels;
using Nemesys.Repositories;

namespace Nemesys.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportRepository reportRepository;
        private readonly IReportLikeRepository reportLikeRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IReportInvestigationRepository reportInvestigationRepository;

        public ReportsController(IReportRepository reportRepository,
            IReportLikeRepository reportLikeRepository,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IReportInvestigationRepository reportInvestigationRepository)
        {
            this.reportRepository = reportRepository;
            this.reportLikeRepository = reportLikeRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.reportInvestigationRepository = reportInvestigationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var liked = false;
            var report = await reportRepository.GetByUrlHandleAsync(urlHandle);
            var reportDetailsViewModel = new RepDetailsViewModel();


            if (report != null)
            {
                var totalLikes = await reportLikeRepository.GetTotalLikes(report.Id);


                if (signInManager.IsSignedIn(User))
                {
                    //Get like for this report for this user if he has previously liked
                    var likesForReports = await reportLikeRepository.GetLikesForReport(report.Id);

                    var userId = userManager.GetUserId(User);

                    if (userId != null)
                    {
                        var likeFromUser = likesForReports.FirstOrDefault(x => x.UserId == Guid.Parse(userId));

                        liked = likeFromUser != null;
                    }
                }



                //get investigations for report
                var reportInvestigationsDomainModel = await reportInvestigationRepository.GetInvestigationsByReportIdAsync(report.Id);

                var reportInvestigationsForView = new List<RepInvestigation>();

				//current investigator
				var currentUserId = userManager.GetUserId(User); // Get the current user ID
				bool isInvestigatedByCurrentUser = false;


				foreach (var repInvestigation in reportInvestigationsDomainModel)
                {
					//current investigator
					if (repInvestigation.UserId.ToString() == currentUserId)
					{
						isInvestigatedByCurrentUser = true; // Set the flag if the current user has already investigated
					}



					reportInvestigationsForView.Add(new RepInvestigation
                    {

                        Description = repInvestigation.Description,
                        DateAdded = repInvestigation.DateAdded,
                        Username = (await userManager.FindByIdAsync(repInvestigation.UserId.ToString())).UserName

                    });
                }


                reportDetailsViewModel = new RepDetailsViewModel
                {
                    Id = report.Id,
                    Heading = report.Heading,
                    PageTitle = report.PageTitle,
                    Content = report.Content,
                    Location = report.Location,
                    Description = report.Description,
                    FeaturedImageUrl = report.FeaturedImageUrl,
                    UrlHandle = urlHandle,
                    PublishedDate = report.PublishedDate,
                    SpottedDate = report.SpottedDate,
                    Author = report.Author,
                    Visible = report.Visible,
                    Tags = report.Tags,
                    TotalLikes = totalLikes,
                    Liked = liked,
                    Investigations = reportInvestigationsForView,
                    Status = report.Status.Name
                };
            }

            return View(reportDetailsViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Index(RepDetailsViewModel reportDetailsViewModel, Guid ReportId)
        {
            if (signInManager.IsSignedIn(User))
            {
                var domainModel = new ReportInvestigation
                {
                    ReportId = reportDetailsViewModel.Id,
                    Description = reportDetailsViewModel.InvestigationDescription,
                    UserId = Guid.Parse(userManager.GetUserId(User)),
                    DateAdded = DateTime.Now,
                    StatusId = 2
                };

				await reportInvestigationRepository.AddAsync(domainModel);

                return RedirectToAction("Index", "Reports", 
                    new { urlHandle = reportDetailsViewModel.UrlHandle});
            }

			return View(reportDetailsViewModel);
			

		}

    }
}
