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

        public PayRollService(IPayRollRepository payRollRepository, IMapper mapper)
        {
            _payRollRepository = payRollRepository;
            _mapper = mapper;
            
        }

        public async Task<IActionResult> createPayroll(PayRollPostDto payrollpost)

        {
            var payroll = _mapper.Map<Payroll>(payrollpost);
            //payroll.PayrollStartDate = DateOnly.ParseExact(payroll.PayrollStartDate.ToString("MM/dd/yyyy"), "MM/dd/yyyy", null);
            //payroll.PayrollEndDate = DateOnly.ParseExact(payroll.PayrollEndDate.ToString("MM/dd/yyyy"), "MM/dd/yyyy", null);
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
                payrollGetDto.EmployeeName=FullName;
                payRollGetDtos.Add(payrollGetDto);
            }

            return payRollGetDtos;
        }
    }
}
