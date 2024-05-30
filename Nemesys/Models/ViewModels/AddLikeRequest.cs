namespace Nemesys.Models.ViewModels
{
	public class AddLikeRequest
	{
        public Guid ReportId { get; set; }

		public Guid UserId { get; set; }
	}
}
