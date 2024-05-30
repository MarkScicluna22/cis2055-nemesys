using Microsoft.EntityFrameworkCore;
using Nemesys.Data;
using Nemesys.Models.Domain;

namespace Nemesys.Repositories
{
	public class ReportInvestigationRepository : IReportInvestigationRepository
	{
		private readonly NemesysDbContext nemesysDbContext;

		public ReportInvestigationRepository(NemesysDbContext nemesysDbContext)
        {
			this.nemesysDbContext = nemesysDbContext;
		}


        public async Task<ReportInvestigation> AddAsync(ReportInvestigation reportInvestigation)
		{
			await nemesysDbContext.ReportInvestigation.AddAsync(reportInvestigation);
			await nemesysDbContext.SaveChangesAsync();
			return reportInvestigation;
		}

		public async Task<IEnumerable<ReportInvestigation>> GetInvestigationsByReportIdAsync(Guid reportId)
		{

			return await nemesysDbContext.ReportInvestigation.Include(x => x.Status).Where(x => x.ReportId == reportId)
				.ToListAsync();
		}

    }
}
