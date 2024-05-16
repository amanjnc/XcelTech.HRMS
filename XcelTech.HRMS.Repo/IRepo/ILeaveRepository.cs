using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Model.Dto;

namespace XcelTech.HRMS.Repo.IRepo
{
    public interface ILeaveRepository
    {

        Task addLeaveToTable(Leave leave, string email);
        //Task updateLeave(Employee employee, string email);
        Task<List<Leave>> GetAllLeaves();

        Task UpdateLeaveStatus(int leaveId, string Status);

        //public Task<List<Leave>> GetAllLeavesAsync();

    }
}
