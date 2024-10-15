using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Dto
{
    public class ReddisUniqueTokenWithUserIdDto
    {
        public int EmployeeId { get; set; }
        public string? AppUserId { get; set; }

        public string PasswordResetToken { get; set; }

        public string Email { get; set; }

    }
}
