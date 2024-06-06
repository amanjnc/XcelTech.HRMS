using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Bloc.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IMapper _mapper;

        public TrainingService(ITrainingRepository trainingRepository, IMapper mapper)
        {
            _trainingRepository = trainingRepository;
            _mapper = mapper;
        }


        public async Task<List<Training>> GetAllTrainingAsync()
        {
            var trainings = await _trainingRepository.GetAllTrainingAsync();
            return trainings;
            //return _mapper.Map<List<TrainingDto>>(trainings);
        }

        public async Task<Training> GetTrainingAsync(int id)
        {
            var training = await _trainingRepository.GetTrainingAsync(id);
            return training;
            //return _mapper.Map<TrainingDto>(training);
        }

        public async Task<TrainingDto> CreateTrainingAsync(TrainingDto training, string email)
        {
            Training _training = _mapper.Map<Training>(training);
            _training.PostedBy = email;
            await _trainingRepository.CreateTrainingAsync(_training);
            //return _mapper.Map<TrainingDto>(training);
            return training;
        }
    }
}
