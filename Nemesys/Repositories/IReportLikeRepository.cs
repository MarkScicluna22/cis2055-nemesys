using Nemesys.Models.Domain;

namespace Nemesys.Repositories
{
    public interface IReportLikeRepository
    {
        Task<int> GetTotalLikes(Guid reportId);

        Task<IEnumerable<ReportLike>> GetLikesForReport(Guid reportId);

        Task<ReportLike> AddLikeForReport(ReportLike reportLike);
    }
}
