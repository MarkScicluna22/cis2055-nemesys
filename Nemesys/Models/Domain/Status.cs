namespace Nemesys.Models.Domain
{
    public class Status
    {
        public int Id { get; set; }

        public string Name { get; set; }


        // Navigation property for related Reports
        public ICollection<Report> Reports { get; set; }
    }
}
