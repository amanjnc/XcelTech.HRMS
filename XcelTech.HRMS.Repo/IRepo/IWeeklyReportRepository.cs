using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Repo.IRepo
{
    public interface IWeeklyReportRepository
    {
        Task<IEnumerable<WeeklyReport>> GetAllReportsAsync();
        Task<WeeklyReport> GetReportByIdAsync(int reportId);
        Task<WeeklyReport> AddReportAsync(WeeklyReport report);
        Task<WeeklyReport> UpdateReportAsync(WeeklyReport report);
        Task<bool> DeleteReportAsync(int reportId);

        Task<IEnumerable<WeeklyReport>> GetUsersReport(int employeeId);
    }

}
