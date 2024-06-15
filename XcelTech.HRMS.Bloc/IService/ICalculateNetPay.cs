using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface ICalculateNetPay
    {
        Task<float> CalculateNetSalary(PayRollPostDto payrollPostDto);
        Task<double> IsPaidLeave(Leave leave, DateOnly date);
    }
}
