using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Model.Profiles;
using XcelTech.HRMS.Repo.IRepo;
using XcelTech.HRMS.Repo.Repo;

namespace XcelTech.HRMS.Bloc.Service
{
    public class PayRollService:IPayRollService
    {
        private readonly IMapper _mapper;
        private readonly IPayRollRepository _payRollRepository;
        private readonly ICalculateNetPay _calculateNetPay;
        private readonly IEmployeeRepository _employeeRepository;

        public PayRollService(IPayRollRepository payRollRepository, IMapper mapper, ICalculateNetPay calculateNetPay,  IEmployeeRepository employeeRepository)
        {
            _payRollRepository = payRollRepository;
            _mapper = mapper;
            _calculateNetPay = calculateNetPay;
            _employeeRepository = employeeRepository;

        }

        public async Task<IActionResult> createPayroll(PayRollPostDto payrollpost)

        {
            var EmployeeId= await _employeeRepository.GetEmployeeIdByEmailAsync(payrollpost.EmployeeEmail); 
            var payroll = _mapper.Map<Payroll>(payrollpost);
            payroll.EmployeeId = EmployeeId;
            payroll.NetPay = await _calculateNetPay.CalculateNetSalary(payrollpost);
            await _payRollRepository.createPayroll(payroll);

            return new OkResult();
        }

        public async Task<List<PayRollGetDto>> getAllPayRolls()

        {
            List<PayRollGetDto> payRollGetDtos = new List<PayRollGetDto>();
            var payrolls = await _payRollRepository.getAllPayRolls();
            foreach (var payroll in payrolls)
            {
                var employeeId = payroll.EmployeeId;
                var FullName = await _payRollRepository.GetEmployeeFullNameByIdAsync(employeeId);
                var payrollGetDto = _mapper.Map<PayRollGetDto>(payroll);
                payrollGetDto.EmployeeEmail = await _employeeRepository.GetEmployeeEmailbyIdAsync(employeeId);
                payrollGetDto.EmployeeName=FullName;
                payRollGetDtos.Add(payrollGetDto);
            }

            return payRollGetDtos;
        }

        public async Task<IEnumerable<Payroll>> GetPayrollsByEmployeeId(int employeeId)
        {
            return await _payRollRepository.GetPayrollsByEmployeeId(employeeId);
        }

        public async Task<IEnumerable<Payroll>> GetPayrollsByStartDate(DateOnly startDate)
        {
            return await _payRollRepository.GetPayrollsByStartDate(startDate);
        }

        public async Task<IActionResult> DeletePayroll(int PayrollId)
        {
              var payroll = await _payRollRepository.DeletePayroll(PayrollId);


                return new OkResult();
           

        }
    }
}
