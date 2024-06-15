using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Model.Dto;


namespace XcelTech.HRMS.Bloc.IService
{
    public interface ILeaveService
    {
        Task<IActionResult> createLeave(LeaveDto leaveDto, string email);
        Task <List<GetLeaveDto>> getAllLeaves();

        Task<IActionResult> UpdateLeaveStatus(int leaveId, string Status);

        Task<(bool Success, string Message)> ApproveLeaveAsync(int leaveId);
        Task<IActionResult> DeleteLeave(int LeaveId);
    }
}
