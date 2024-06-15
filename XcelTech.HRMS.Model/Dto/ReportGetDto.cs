using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Dto
{
    public class ReportGetDto
    {
        public int ReportId { get; set; }

        public int EmployeeId { get; set; }

        public string Plan { get; set; }
        public string WhatIDone { get; set; }
        public string FuturePlans { get; set; }

        public DateTime SubmittedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
