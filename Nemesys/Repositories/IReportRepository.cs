using Nemesys.Models.Domain;

namespace Nemesys.Repositories
{
    public interface IReportRepository
    {

        Task<IEnumerable<Report>> GetAllAsync();

        //status in home page
        Task<IEnumerable<Report>> GetAllWithStatusAsync();

        Task<IEnumerable<Report>> GetAllByUserIdAsync(string userId);

        Task<Report?> GetAsync(Guid id);

        Task<Report?> GetByUrlHandleAsync(string urlHandle);

        Task<Report> AddAsync(Report report);

        Task<Report?> UpdateAsync(Report report);

        Task<Report?> DeleteAsync(Guid id);




        //hall of fame
        Task<IEnumerable<ReporterRanking>> GetTopReportersAsync(int year);


	}
}
