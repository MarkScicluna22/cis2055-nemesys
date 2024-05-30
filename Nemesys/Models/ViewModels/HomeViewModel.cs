using Nemesys.Models.Domain;

namespace Nemesys.Models.ViewModels
{
	public class HomeViewModel
	{
		public IEnumerable<Report> Reports { get; set; }

		public IEnumerable<Tag> Tags { get; set; }

        public IEnumerable<Status> Status { get; set; }

        public IEnumerable<Status> StatusId { get; set; }
    }
}
