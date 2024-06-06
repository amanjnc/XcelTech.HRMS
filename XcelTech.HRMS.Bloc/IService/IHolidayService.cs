using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface IHolidayService
    {
        Task<IEnumerable<Holiday>> GetAllHolidays();
        Task<Holiday> GetHolidayById(int id);
        Task<Holiday> CreateHoliday(Holiday holiday);
        Task<Holiday> UpdateHoliday(Holiday holiday);
        Task<bool> DeleteHoliday(int id);
    }
}
