namespace Nemesys.Models.Domain
{
	public class ReportInvestigation
	{
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid ReportId { get; set; }

        public Guid UserId { get; set; }

        public DateTime DateAdded { get; set; }

        //status
        public int StatusId { get; set; }
        public Status Status { get; set; }

    }
}
