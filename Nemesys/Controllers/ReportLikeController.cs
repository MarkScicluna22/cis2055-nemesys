using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Models.Domain;
using Nemesys.Models.ViewModels;
using Nemesys.Repositories;

namespace Nemesys.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportLikeController : ControllerBase
	{
		private readonly IReportLikeRepository reportLikeRepository;

		public ReportLikeController(IReportLikeRepository reportLikeRepository)
		{
			this.reportLikeRepository = reportLikeRepository;
		}



		[HttpPost]
		[Route("Add")]
		public async Task<IActionResult> AddLike([FromBody] AddLikeRequest addLikeRequest)
		{

			var model = new ReportLike
			{
				ReportId = addLikeRequest.ReportId,
				UserId = addLikeRequest.UserId,
			};

			await reportLikeRepository.AddLikeForReport(model);

			return Ok();
		}



		[HttpGet]
		[Route("{reportId:Guid}/totalLikes")]
		public async Task<IActionResult> GetTotalLikesForReport([FromRoute] Guid reportId)
		{
			var totalLikes = await reportLikeRepository.GetTotalLikes(reportId);

			return Ok(totalLikes);
		}
	}
}
