using Nemesys.Models.Domain;

namespace Nemesys.Repositories
{
	public interface IReportInvestigationRepository
	{

		Task<ReportInvestigation> AddAsync(ReportInvestigation reportInvestigation);

		Task<IEnumerable<ReportInvestigation>> GetInvestigationsByReportIdAsync(Guid reportId);


	}
}
