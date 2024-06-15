using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Model.Dto;

namespace XcelTech.HRMS.Repo.IRepo
{
    public interface ITrainingRepository
    {
        Task CreateTrainingAsync(Training training);
        Task<List<Training>> GetAllTrainingAsync();
        Task<Training> GetTrainingAsync(int id);

        Task<Training> Deletetraining(int TrainingId);

    }
}

