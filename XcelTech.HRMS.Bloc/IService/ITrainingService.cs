using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface ITrainingService
    {
        Task<TrainingDto> CreateTrainingAsync(TrainingDto training ,string email);
        Task<List<Training>> GetAllTrainingAsync();
        Task<Training> GetTrainingAsync(int id);

        Task<IActionResult> Deletetraining(int TrainingId);
    }
}
