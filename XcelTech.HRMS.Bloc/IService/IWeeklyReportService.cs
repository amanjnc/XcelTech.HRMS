using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface IWeeklyReportService
    {
        Task<IEnumerable<ReportGetDto>> GetAllReportsAsync();
        Task<ReportGetDto> GetReportByIdAsync(int reportId);
        Task<WeeklyReport> CreateReportAsync(ReportDto dto, string userEmail);
        Task<WeeklyReport> UpdateReportAsync(int reportId, ReportDto dto);
        Task<bool> DeleteReportAsync(int reportId);

        Task<IEnumerable<ReportGetDto>> GetUsersReport(string email);
    }

}
