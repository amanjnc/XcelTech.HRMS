using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Bloc.Service;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingsController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateTraining([FromBody] TrainingDto training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
                await _trainingService.CreateTrainingAsync(training,email);
                return Ok(training);
            }
            catch (Exception ex)
            {
                // Handle any errors
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Training>>> GetAllTrainings()
        {
            var trainings = await _trainingService.GetAllTrainingAsync();
            return Ok(trainings);
        }

        [HttpGet("{id}", Name = "GetTrainingById")]
        public async Task<ActionResult<Training>> GetTrainingById(int id)
        {
            var training = await _trainingService.GetTrainingAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            return Ok(training);
        }
    }
}

