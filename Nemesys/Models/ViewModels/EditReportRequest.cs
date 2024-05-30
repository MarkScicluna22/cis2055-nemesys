using Microsoft.AspNetCore.Mvc.Rendering;

namespace Nemesys.Models.ViewModels
{
    public class EditReportRequest
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


        //Display Tags
        public IEnumerable<SelectListItem> Tags { get; set; }

        //Colllect tags
        public string[] SelectedTags { get; set; } = Array.Empty<string>();
    }
}
