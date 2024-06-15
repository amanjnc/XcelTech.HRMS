using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo;
using XcelTech.HRMS.Repo.IRepo;
using XcelTech.HRMS.Repo.Repo;

namespace XcelTech.HRMS.Bloc.Service
{
    public class CalculateNetPay : ICalculateNetPay
    {
        private readonly IHolidayRepository _holidayRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveRepository _leaveRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IEmployeeRepository _employeeRepository;

        public CalculateNetPay(ILeaveRepository leaveRepository, IHolidayRepository holidayRepository, ApplicationDbContext applicationDbContext, IMapper mapper,IAttendanceRepository attendanceRepository, IEmployeeRepository employeeRepository)
        {
            _leaveRepository = leaveRepository;
            _holidayRepository = holidayRepository;
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _attendanceRepository = attendanceRepository;
            _employeeRepository = employeeRepository;

        }





        public async Task<float> CalculateNetSalary(PayRollPostDto payrollPostDto)
        {
            var EmployeeId = await _employeeRepository.GetEmployeeIdByEmailAsync(payrollPostDto.EmployeeEmail);
            var attendance = await _attendanceRepository.GetAttendancesByEmployeeIdAndDateRange(EmployeeId, payrollPostDto.PayrollStartDate, payrollPostDto.PayrollEndDate);
            var attendanceDtos = _mapper.Map<List<AttendanceDto>>(attendance);
            if (attendance == null)
            {
                
                throw new InvalidOperationException("Attendances list is null.");
            }

            var holidays = await _holidayRepository.GetHolidaysInDateRange(payrollPostDto.PayrollStartDate, payrollPostDto.PayrollEndDate);
            var leaves = await _leaveRepository.GetLeavesByEmployeeIdAndDateRange(EmployeeId, payrollPostDto.PayrollStartDate, payrollPostDto.PayrollEndDate);

            double netPay = payrollPostDto.Amount;
            double dailySalary = payrollPostDto.Amount / (payrollPostDto.PayrollEndDate.DayNumber - payrollPostDto.PayrollStartDate.DayNumber + 1);

            for (var date = payrollPostDto.PayrollStartDate; date <= payrollPostDto.PayrollEndDate; date = date.AddDays(1))
            {
                if (attendanceDtos.Any(a => a.date == date))
                {
                    continue;
                }

                if (holidays.Any(h => h.HolidayDate == date) || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }


                var leave = leaves.FirstOrDefault(l => l.StartDate <= date && l.EndDate >= date);
                if (leave != null)
                {
                    var percentage = await IsPaidLeave(leave, date);
                    netPay -= dailySalary * (1 - percentage);
                    continue;
                }

                netPay -= dailySalary; // Deduct daily salary for the absence
            }
            float _netPay = (float)netPay;
            return _netPay + payrollPostDto.Bonus;
        }



        public async Task<double> IsPaidLeave(Leave leave, DateOnly date)
        {
            double paymentPercentage = 0;
            var daysSinceLeaveStart = date.DayNumber - leave.StartDate.DayNumber;

            var leaveType = leave.LeaveType;

            LeaveTypes _leaveType = await _leaveRepository.GetLeaveTypeByNameAsync(leaveType);

            /*if (_leaveType == null || _leaveType.LeavePaymentDetails == null || !_leaveType.LeavePaymentDetails.Any())
            {
                // Handle the case where there are no payment details
                return paymentPercentage;
            }*/

            // Find the matching LeavePaymentDetail for the given number of days
            /*var paymentDetail = _leaveType.LeavePaymentDetails
                .FirstOrDefault(detail => daysSinceLeaveStart >= detail.DaysFrom && daysSinceLeaveStart <= detail.DaysTo);*/

            var paymentDetail = await _applicationDbContext.LeavePaymentDetails
                .FirstOrDefaultAsync(l => l.LeaveTypeId == _leaveType.LeaveTypeId && l.DaysFrom <= daysSinceLeaveStart && daysSinceLeaveStart <= l.DaysTo);
                

            if (paymentDetail != null)
            {
                // Set the payment percentage based on the LeavePaymentDetail
                paymentPercentage = paymentDetail.PaymentPercentage;
            }

            return paymentPercentage;
        }


    }
}
