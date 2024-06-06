using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace XcelTech.HRMS.Repo.Repo
{
    public class HolidayRepository:IHolidayRepository
    {
        private readonly ApplicationDbContext _context;

        public HolidayRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Holiday>> GetAllHolidays()
        {
            return await _context.Holidays.ToListAsync();
        }

        public async Task<Holiday> GetHolidayById(int id)
        {
            return await _context.Holidays.FindAsync(id);
        }

        public async Task<Holiday> CreateHoliday(Holiday holiday)
        {
            _context.Holidays.Add(holiday);
            await _context.SaveChangesAsync();
            return holiday;
        }

        public async Task<Holiday> UpdateHoliday(Holiday holiday)
        {
            var id = holiday.HolidayId;
            var existingHoliday = await _context.Holidays.FindAsync(id);
            if (existingHoliday == null) return null;

            existingHoliday.HolidayName = holiday.HolidayName;
            existingHoliday.HolidayDate = holiday.HolidayDate;
            existingHoliday.HolidayDescription = holiday.HolidayDescription;

            _context.Holidays.Update(existingHoliday);
            await _context.SaveChangesAsync();
            return existingHoliday;
        }

        public async Task<bool> DeleteHoliday(int id)
        {
            var holiday = await _context.Holidays.FindAsync(id);
            if (holiday == null) return false;

            _context.Holidays.Remove(holiday);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
