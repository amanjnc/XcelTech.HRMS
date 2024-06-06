using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Repo.IRepo;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using XcelTech.HRMS.Repo.Repo;
using Microsoft.EntityFrameworkCore;

namespace XcelTech.HRMS.Bloc.Service
{
    public class LeaveService : ILeaveService
    {

        private readonly IMapper _mapper;
        private readonly ILeaveRepository _leaveRepository;
        private readonly IHolidayRepository _holidayRepository;

        public LeaveService(IMapper mapper, ILeaveRepository leaveRepository, IHolidayRepository holidayRepository)
        {
            _mapper = mapper;
            _leaveRepository = leaveRepository;
            _holidayRepository = holidayRepository;
            
        }

        public  async Task<IActionResult> createLeave(LeaveDto leaveDto, string email)
        {
            if (email == null)
            {
                Console.WriteLine("You have failed this coty this shit hurts");
                // Token validation failed or user not found
                return new UnauthorizedResult();
            }

            var leave = _mapper.Map<Leave>(leaveDto);

            int useddays = CalculateUsedDaysAsync(leave.StartDate, leave.EndDate, leave.LeaveType).Result;
            leave.UsedDays = useddays;

            await _leaveRepository.addLeaveToTable(leave, email);

            return new OkResult();
        }

        public async Task<List<GetLeaveDto>> getAllLeaves()
        {
            var leaves = await _leaveRepository.GetAllLeaves();
            var leaveDtos = _mapper.Map<List<GetLeaveDto>>(leaves);

            //var employeeGetDtos = _mapper.Map<List<EmployeeGetDto>>(employees);

            return leaveDtos;
        }

        public async Task<IActionResult> UpdateLeaveStatus(int leaveId, string Status)
        {

            await _leaveRepository.UpdateLeaveStatus(leaveId, Status);

            return new OkResult();
        }


        private async Task<int> CalculateUsedDaysAsync(DateOnly startDate, DateOnly endDate, string leaveType)
        {
            if (string.IsNullOrEmpty(leaveType))
            {
                throw new ArgumentNullException(nameof(leaveType), "Leave type cannot be null or empty.");
            }

            if (startDate > endDate)
            {
                throw new ArgumentException("Start date cannot be later than end date.");
            }

            int totalDays = 0;
            DateOnly currentDate = startDate;

            bool deductDays;
            try
            {
                deductDays = await GetDeductctDaysByLeaveTypeNameAsync(leaveType);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to determine if days should be deducted based on leave type.", ex);
            }

            if (deductDays)
            {
                IEnumerable<Holiday> holidays;
                try
                {
                    holidays = await _holidayRepository.GetAllHolidays();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Failed to retrieve holidays from the repository.", ex);
                }

                if (holidays == null)
                {
                    throw new InvalidOperationException("Holiday list is null.");
                }

                var holidayDates = holidays.Select(h => h.HolidayDate).ToHashSet();

                while (currentDate <= endDate)
                {
                    if (currentDate.DayOfWeek != DayOfWeek.Saturday &&
                        currentDate.DayOfWeek != DayOfWeek.Sunday &&
                        !holidayDates.Contains(currentDate))
                    {
                        totalDays++;
                    }
                    currentDate = currentDate.AddDays(1);
                }
            }
            else
            {
                totalDays = endDate.DayNumber - startDate.DayNumber + 1;
            }

            return totalDays;
        }

        public async Task<(bool Success, string Message)> ApproveLeaveAsync(int leaveId)
        {
            var leave = await _leaveRepository.GetLeaveByIdAsync(leaveId);
            if (leave == null)
            {
                return (false, "Leave request not found.");
            }

            var allLeaves = await _leaveRepository.GetLeavesByEmployeeIdAndTypeAsync(leave.EmployeeId, leave.LeaveType);

            int totalUsedDays = allLeaves.Where(l => l.status == "Approved").Sum(l => l.UsedDays); allLeaves.Sum(l => l.UsedDays);

            var leaveType = await _leaveRepository.GetLeaveTypeByNameAsync(leave.LeaveType);
            if (leaveType == null)
            {
                return (false, "Leave type not found.");
            }

            if (totalUsedDays + leave.UsedDays > leaveType.TotalAllowedDays)
            {
                return (false, "Approval exceeds allowed leave days.");
            }

            bool updateResult = await _leaveRepository.UpdateLeaveStatus(leaveId, "Approved");
            if (!updateResult)
            {
                return (false, "Failed to update leave status.");
            }

            return (true, "Leave approved successfully.");
        }

        public async Task<bool> GetDeductctDaysByLeaveTypeNameAsync(string leaveTypeName)
        {
            var leaveType = await _leaveRepository.GetLeaveTypeByNameAsync(leaveTypeName);
            return leaveType.DeductDays; // Default to "no" if not found
        }

    }
}
