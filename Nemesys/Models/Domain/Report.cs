using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Numerics;

namespace Nemesys.Models.Domain
{
    public class Report
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
        public string Author { get; set;}
        public bool Visible { get; set; }

        //status
        public int StatusId { get; set; }
        public Status Status { get; set; }




        //Navigation property
        public ICollection<Tag> Tags { get; set; }


        //assign to user
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public ICollection<ReportLike> Likes { get; set; }

		public ICollection<ReportInvestigation> Investigations { get; set; }

        //username for hall of fame
        //public string Username { get; set; }


    }
}
