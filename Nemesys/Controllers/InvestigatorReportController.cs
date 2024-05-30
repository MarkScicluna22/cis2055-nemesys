using Microsoft.AspNetCore.Mvc;
using Nemesys.Models.ViewModels;
using Nemesys.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nemesys.Models.Domain;
using Nemesys.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Nemesys.Controllers
{

    [Authorize(Roles = "Reporter")]
    public class InvestigatorReportController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IReportRepository reportRepository;

        public InvestigatorReportController(ITagRepository tagRepository, IReportRepository reportRepository)
        {
            this.tagRepository = tagRepository;
            this.reportRepository = reportRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //get tags from repository
            var tags = await tagRepository.GetAllAsync();

            var model = new AddReportRequest
            {
                Tags = tags.Select(x => new SelectListItem { Text = x.DisplayName, Value = x.Id.ToString() })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddReportRequest addReportRequest)
        {
            // Get the currently logged-in user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        
            //Map view model to domain model
            var report = new Report
            {
                Heading = addReportRequest.Heading,
                PageTitle = addReportRequest.PageTitle,
                Content = addReportRequest.Content,
                Location = addReportRequest.Location,
                Description = addReportRequest.Description,
                FeaturedImageUrl = addReportRequest.FeaturedImageUrl,
                UrlHandle = addReportRequest.UrlHandle,
                PublishedDate = addReportRequest.PublishedDate,
                SpottedDate = addReportRequest.SpottedDate,
                Author = addReportRequest.Author,
                Visible = addReportRequest.Visible,
                UserId = userId,
                StatusId = 1
            };

            //Map tags from selected tags
            var selectedTags = new List<Tag>();
            foreach(var selectedTagId in addReportRequest.SelectedTags)
            {
                var selectedTagIdAsGuid = Guid.Parse(selectedTagId);
                var existingTag = await tagRepository.GetAsync(selectedTagIdAsGuid);

                if (existingTag != null)
                {
                    selectedTags.Add(existingTag);
                }
            }

            //mapping tags back to domain model
            report.Tags = selectedTags;

            await reportRepository.AddAsync(report);

            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            //call the repository
            var reports = await reportRepository.GetAllAsync();

            return View(reports);
        }

        //for non investigators
        [HttpGet]
        public async Task<IActionResult> MyList()
        {
            // Get the currently logged-in user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            //call the repository
            var reports = await reportRepository.GetAllByUserIdAsync(userId);

            return View(reports);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            //retreive result from repository
            var report = await reportRepository.GetAsync(id);
            var tagsDomainModel = await tagRepository.GetAllAsync();

            if(report != null)
            {
                //map the domain model to the view model
                var model = new EditReportRequest
                {
                    Id = report.Id,
                    Heading = report.Heading,
                    PageTitle = report.PageTitle,
                    Content = report.Content,
                    Location = report.Location,
                    Description = report.Description,
                    FeaturedImageUrl = report.FeaturedImageUrl,
                    UrlHandle = report.UrlHandle,
                    PublishedDate = report.PublishedDate,
                    SpottedDate = report.SpottedDate,
                    Author = report.Author,
                    Visible = report.Visible,
                    Tags = tagsDomainModel.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }),
                    SelectedTags = report.Tags.Select(x => x.Id.ToString()).ToArray()
                };

                return View(model);
            }
                       

            //pass data to view
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditReportRequest editReportRequest)
        {
            //map view model back to domain model
            var reportDomainModel = new Report
            {
                Id = editReportRequest.Id,
                Heading = editReportRequest.Heading,
                PageTitle = editReportRequest.PageTitle,
                Content = editReportRequest.Content,
                Location = editReportRequest.Location,
                Description = editReportRequest.Description,
                FeaturedImageUrl = editReportRequest.FeaturedImageUrl,
                UrlHandle = editReportRequest.UrlHandle,
                PublishedDate = editReportRequest.PublishedDate,
                SpottedDate = editReportRequest.SpottedDate,
                Author = editReportRequest.Author,
                Visible = editReportRequest.Visible,
                StatusId = 2
            };

            //map tags to domain model
            var selectedTags = new List<Tag>();
            foreach(var selectedTag in editReportRequest.SelectedTags)
            {
                if (Guid.TryParse(selectedTag,out var tag))
                {
                    var foundTag = await tagRepository.GetAsync(tag);

                    if (foundTag != null)
                    {
                        selectedTags.Add(foundTag);
                    }
                }
            }

            reportDomainModel.Tags = selectedTags;



            //Submit Info to repository for update
            var updatedReport = await reportRepository.UpdateAsync(reportDomainModel);


            if(updatedReport != null)
            {
                return RedirectToAction("Edit");
            }

            return RedirectToAction("Edit");
            //redirect to GET
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditReportRequest editReportRequest)
        {
            //talk to repos to delete report and tags
            var deletedReport = await reportRepository.DeleteAsync(editReportRequest.Id);

            if (deletedReport != null)
            {
                //show success
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { id= editReportRequest.Id});
            //Display response
        }



		//investigation statuses
		[HttpPost]
		public async Task<IActionResult> OpenInvestigation(Guid ReportId, RepDetailsViewModel repDetailsViewModel)
		{
			var report = await reportRepository.GetAsync(ReportId);

			report.StatusId = 2;

			await reportRepository.UpdateAsync(report);

			return RedirectToAction("Index", "Reports",
					new { urlHandle = repDetailsViewModel.UrlHandle });
		}


		[HttpPost]
	    public async Task<IActionResult> CloseInvestigation(Guid ReportId, RepDetailsViewModel repDetailsViewModel)
        {
            var report = await reportRepository.GetAsync(ReportId);

            report.StatusId = 3;

            await reportRepository.UpdateAsync(report);

			return RedirectToAction("Index", "Reports",
					new { urlHandle = repDetailsViewModel.UrlHandle });
		}

		[HttpPost]
        public async Task<IActionResult> NoActionNeeded(Guid ReportId, RepDetailsViewModel repDetailsViewModel)
        {
            var report = await reportRepository.GetAsync(ReportId);

            report.StatusId = 4;

            await reportRepository.UpdateAsync(report);

			return RedirectToAction("Index", "Reports",
					new { urlHandle = repDetailsViewModel.UrlHandle });
		}


	}
}
