using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Bloc.Service
{
    public class HolidayService:IHolidayService
    {
        private readonly IHolidayRepository _holidayRepository;

        public HolidayService(IHolidayRepository holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }

        public async Task<IEnumerable<Holiday>> GetAllHolidays()
        {
            return await _holidayRepository.GetAllHolidays();
        }

        public async Task<Holiday> GetHolidayById(int id)
        {
            return await _holidayRepository.GetHolidayById(id);
        }

        public async Task<Holiday> CreateHoliday(Holiday holiday)
        {
            return await _holidayRepository.CreateHoliday(holiday);
        }

        public async Task<Holiday> UpdateHoliday(Holiday holiday)
        {
            return await _holidayRepository.UpdateHoliday(holiday);
        }

        public async Task<bool> DeleteHoliday(int id)
        {
            return await _holidayRepository.DeleteHoliday(id);
        }
    }
}
