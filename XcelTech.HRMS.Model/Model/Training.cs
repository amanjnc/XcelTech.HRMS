using System.ComponentModel.DataAnnotations.Schema;

namespace XcelTech.HRMS.Model.Model
{

    public class Training
    {
        public int TrainingId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public string PostedBy {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}