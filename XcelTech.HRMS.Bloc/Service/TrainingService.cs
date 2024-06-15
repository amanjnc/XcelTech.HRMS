using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;
using XcelTech.HRMS.Repo.Repo;

namespace XcelTech.HRMS.Bloc.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IMapper _mapper;
        private IFilehandleService _filehandleService;

        public TrainingService(ITrainingRepository trainingRepository, IMapper mapper, IFilehandleService filehandleService)
        {
            _trainingRepository = trainingRepository;
            _mapper = mapper;
            _filehandleService = filehandleService;
        }


        public async Task<List<Training>> GetAllTrainingAsync()
        {
            var trainings = await _trainingRepository.GetAllTrainingAsync();
            foreach (var training in trainings)
            {
                training.Url = await _filehandleService.FileToBase64Async(training.Url);
            }

            return trainings;
            //return _mapper.Map<List<TrainingDto>>(trainings);
        }

        public async Task<Training> GetTrainingAsync(int id)
        {
            var training = await _trainingRepository.GetTrainingAsync(id);
            training.Url = await _filehandleService.FileToBase64Async(training.Url);
            return training;
            //return _mapper.Map<TrainingDto>(training);
        }

        public async Task<TrainingDto> CreateTrainingAsync(TrainingDto training, string email)
        {
            Training _training = _mapper.Map<Training>(training);
            _training.PostedBy = email;
            _training.Url = await _filehandleService.SaveFile(training.Url, "Url");
         
            await _trainingRepository.CreateTrainingAsync(_training);
            //return _mapper.Map<TrainingDto>(training);
            return training;
        }

        public async Task<IActionResult> Deletetraining(int TrainingId)
        {
            try
            {
                var training = await _trainingRepository.Deletetraining(TrainingId);


                _filehandleService.DeleteFiles(training.Url);

                // Remove the employee file from the database

                return new OkResult();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in an appropriate way
                return new ObjectResult(new { error = $"An error occurred: {ex.Message}" })
                {
                    StatusCode = 500
                };
            }
        }
    }
}
