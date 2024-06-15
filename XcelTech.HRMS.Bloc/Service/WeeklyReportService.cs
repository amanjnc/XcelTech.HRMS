using AutoMapper;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;
using XcelTech.HRMS.Repo.Repo;

namespace XcelTech.HRMS.Bloc.Service
{
    public class WeeklyReportService : IWeeklyReportService
    {
        private readonly IWeeklyReportRepository _weeklyReportRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public WeeklyReportService(IWeeklyReportRepository weeklyReportRepository, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _weeklyReportRepository = weeklyReportRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReportGetDto>> GetAllReportsAsync()
        {
            var report =  await _weeklyReportRepository.GetAllReportsAsync();

            var reportdtos = _mapper.Map<List<ReportGetDto>>(report);

            return reportdtos;
        }

        public async Task<ReportGetDto> GetReportByIdAsync(int reportId)
        {
            var report = await _weeklyReportRepository.GetReportByIdAsync(reportId);

            var reportdto = _mapper.Map<ReportGetDto>(report);

            return reportdto;
        }

        public async Task<WeeklyReport> CreateReportAsync(ReportDto dto, string userEmail)
        {
            var employeeId = await _employeeRepository.GetEmployeeIdByEmailAsync(userEmail);
  

            var report= _mapper.Map<WeeklyReport>(dto);
            report.EmployeeId = employeeId;
            report.SubmittedDate = DateTime.UtcNow;
            report.ModifiedDate = DateTime.UtcNow;

            

            return await _weeklyReportRepository.AddReportAsync(report);
        }

        public async Task<WeeklyReport> UpdateReportAsync(int reportId, ReportDto dto)
        {
            var report = await _weeklyReportRepository.GetReportByIdAsync(reportId);


            report.WhatIDone = dto.WhatIDone;
            report.FuturePlans = dto.FuturePlans;
            report.Plan = dto.Plan;
            report.ModifiedDate = DateTime.UtcNow;

            return await _weeklyReportRepository.UpdateReportAsync(report);
        }

        public async Task<bool> DeleteReportAsync(int reportId)
        {
            return await _weeklyReportRepository.DeleteReportAsync(reportId);
        }

        public async Task<IEnumerable<ReportGetDto>> GetUsersReport(string email)
        {
            var employeeId = await _employeeRepository.GetEmployeeIdByEmailAsync(email);
            var report = await _weeklyReportRepository.GetUsersReport(employeeId);
            var reportdtos = _mapper.Map<List<ReportGetDto>>(report);

            return reportdtos;
        }
    }

}
