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

namespace XcelTech.HRMS.Bloc.Service
{
    public class LeaveService : ILeaveService
    {

        private readonly IMapper _mapper;
        private readonly ILeaveRepository _leaveRepository;

        public LeaveService(IMapper mapper, ILeaveRepository leaveRepository)
        {
            _mapper = mapper;
            _leaveRepository = leaveRepository;
            
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

            await _leaveRepository.addLeaveToTable(leave, email);

            return new OkResult();
        }

        public async Task<List<Leave>> getAllLeaves()
        {
            var leaves = await _leaveRepository.GetAllLeaves();

            //var employeeGetDtos = _mapper.Map<List<EmployeeGetDto>>(employees);

            return leaves;
        }

        public async Task<IActionResult> UpdateLeaveStatus(int leaveId, string Status)
        {

            await _leaveRepository.UpdateLeaveStatus(leaveId, Status);

            return new OkResult();
        }
    }
}
