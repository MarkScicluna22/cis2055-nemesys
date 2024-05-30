using Nemesys.Models.Domain;

namespace Nemesys.Models.ViewModels
{
    public class RepDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }

        public string Location { get; set; }
        public string Description { get; set; }
        public string? FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }

        public DateTime SpottedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }

        public string Status { get; set; }

        //public int StatusId { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public int TotalLikes { get; set; }

        public bool Liked { get; set; }

		public string InvestigationDescription { get; set; }

		public IEnumerable<RepInvestigation> Investigations { get; set; }

        //one user can investigate only
		public bool IsInvestigatedByCurrentUser { get; set; }
	}
}
