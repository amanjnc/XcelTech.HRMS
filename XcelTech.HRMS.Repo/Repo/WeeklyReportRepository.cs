using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace XcelTech.HRMS.Repo.Repo
{
    public class WeeklyReportRepository : IWeeklyReportRepository
    {
        private readonly ApplicationDbContext _context;

        public WeeklyReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WeeklyReport>> GetAllReportsAsync()
        {
            return await _context.WeeklyReports.ToListAsync();
        }

        public async Task<WeeklyReport> GetReportByIdAsync(int reportId)
        {
            return await _context.WeeklyReports.FindAsync(reportId);
        }

        public async Task<WeeklyReport> AddReportAsync(WeeklyReport report)
        {
            _context.WeeklyReports.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<WeeklyReport> UpdateReportAsync(WeeklyReport report)
        {
            _context.WeeklyReports.Update(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<bool> DeleteReportAsync(int reportId)
        {
            var report = await _context.WeeklyReports.FindAsync(reportId);
            if (report == null)
            {
                return false;
            }

            _context.WeeklyReports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<WeeklyReport>> GetUsersReport(int employeeId)
        {
            return await _context.WeeklyReports
                             .Where(r => r.EmployeeId == employeeId)
                             .ToListAsync();
        }
    }

}
