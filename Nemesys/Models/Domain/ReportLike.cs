namespace Nemesys.Models.Domain
{
    public class ReportLike
    {
        public Guid Id { get; set; }

        public Guid ReportId { get; set; }

        public Guid UserId { get; set; }
    }
}
