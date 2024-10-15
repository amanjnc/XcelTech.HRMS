namespace XcelTech.HRMS.Model.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateOnly ProjectStartDate { get; set; }
        public DateOnly ProjectEndDate { get; set; }

        public string Status { get; set; }

    }
}
