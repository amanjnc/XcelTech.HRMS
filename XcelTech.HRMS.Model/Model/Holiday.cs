using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Model
{
    public class Holiday
    {
        public int HolidayId {  get; set; }

        public string HolidayName { get; set; }

        public DateOnly HolidayDate { get; set; }
        public string? HolidayDescription { get; set; }
    }
}
