using Microsoft.AspNetCore.Mvc.Rendering;
using Nemesys.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Nemesys.Models.ViewModels
{
    public class AddReportRequest
    {
        [Required]
        public string Heading { get; set; }
        [Required]
        public string PageTitle { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Description { get; set; }
        public string? FeaturedImageUrl { get; set; }
        [Required]
        public string UrlHandle { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]

        public DateTime SpottedDate { get; set; }
        [Required]
        public string Author { get; set; }
       
        public bool Visible { get; set; }
        

        //status
        public Status Status { get; set; }


        //Display Tags
        public IEnumerable<SelectListItem> Tags { get; set; }

        //Colllect tags
        public string[] SelectedTags { get; set; } = Array.Empty<string>();
    }
}
