
using Microsoft.EntityFrameworkCore;
using Nemesys.Data;
using Nemesys.Models.Domain;

namespace Nemesys.Repositories
{
    public class ReportLikeRepository : IReportLikeRepository
    {
        private readonly NemesysDbContext nemesysDbContext;

        public ReportLikeRepository(NemesysDbContext nemesysDbContext)
        {
            this.nemesysDbContext = nemesysDbContext;
        }

		public async Task<ReportLike> AddLikeForReport(ReportLike reportLike)
		{
            await nemesysDbContext.ReportLike.AddAsync(reportLike);
            await nemesysDbContext.SaveChangesAsync();

            return reportLike;
		}

		public async Task<IEnumerable<ReportLike>> GetLikesForReport(Guid reportId)
		{
			return await nemesysDbContext.ReportLike.Where(XmlConfigurationExtensions => XmlConfigurationExtensions.ReportId == reportId).ToListAsync();
		}

		public async Task<int> GetTotalLikes(Guid reportId)
        {
            return await nemesysDbContext.ReportLike
                .CountAsync(x => x.ReportId == reportId);
        }
    }
}
