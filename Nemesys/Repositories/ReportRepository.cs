using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Nemesys.Data;
using Nemesys.Models.Domain;

namespace Nemesys.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly NemesysDbContext nemesysDbContext;

        public ReportRepository(NemesysDbContext nemesysDbContext)
        {
            this.nemesysDbContext = nemesysDbContext;
        }

        public async Task<Report> AddAsync(Report report)
        {
            await nemesysDbContext.AddAsync(report);
            await nemesysDbContext.SaveChangesAsync();
            return report;
        }

        public async Task<Report?> DeleteAsync(Guid id)
        {
            var existingReport=await nemesysDbContext.Reports.FindAsync(id);

            if (existingReport != null)
            {
                nemesysDbContext.Reports.Remove(existingReport);
                await nemesysDbContext.SaveChangesAsync();
                return existingReport;
            }

            return null;
        }

        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            return await nemesysDbContext.Reports.Include(x => x.Tags).Include(r => r.Status).ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetAllWithStatusAsync()
        {
            return await nemesysDbContext.Reports.Include(x => x.Tags).Include(r => r.Status).ToListAsync();
        }

        //get according to user
        public async Task<IEnumerable<Report>> GetAllByUserIdAsync(string userId)
        {

            return await nemesysDbContext.Reports
                                .Where(r => r.UserId == userId)
                                .Include(r => r.Tags)
                                .Include(r => r.Status)
                                .ToListAsync();
        }


        public async Task<Report?> GetAsync(Guid id)
        {
            return await nemesysDbContext.Reports.Include(x => x.Tags).Include( x => x.Status).FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Report?> GetByUrlHandleAsync(string urlHandle)
        {
            return await nemesysDbContext.Reports.Include(x => x.Tags).Include(x => x.Status)
                .FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<Report?> UpdateAsync(Report report)
        {
           var existingReport= await nemesysDbContext.Reports.Include(x=> x.Tags)
                .FirstOrDefaultAsync(x =>x.Id == report.Id);

            if (existingReport != null)
            {
                existingReport.Id= report.Id;
                existingReport.Heading= report.Heading;
                existingReport.PageTitle= report.PageTitle;
                existingReport.Content= report.Content;
                existingReport.Location= report.Location;
                existingReport.Description= report.Description;
                existingReport.FeaturedImageUrl = report.FeaturedImageUrl;
                existingReport.UrlHandle= report.UrlHandle;
                existingReport.PublishedDate= report.PublishedDate;
                existingReport.SpottedDate= report.SpottedDate;
                existingReport.Author= report.Author;
                existingReport.Visible= report.Visible;
                existingReport.StatusId = report.StatusId;
                existingReport.Tags= report.Tags;

                await nemesysDbContext.SaveChangesAsync();
                return existingReport;

            }

            return null;
        }

        //hall of fame
		public async Task<IEnumerable<ReporterRanking>> GetTopReportersAsync(int year)
		{
			var startDate = new DateTime(year, 1, 1);
			var endDate = new DateTime(year, 12, 31);

            var topReporters = await nemesysDbContext.Reports
                .Include(r => r.User)
                .Where(r => r.PublishedDate >= startDate && r.PublishedDate <= endDate)
                .GroupBy(r => r.User.UserName)
                .Select(g => new ReporterRanking
                {
                    Username = g.Key,
                    ReportCount = g.Count()
                })
                .Take(10)
                .OrderByDescending(r => r.ReportCount)
                .ToListAsync();


            return topReporters;
        }
	}
}
