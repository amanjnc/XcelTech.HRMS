using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Repo.Repo
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateTrainingAsync(Training training)
        {
            await _context.Training.AddAsync(training);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Training>> GetAllTrainingAsync()
        {
            return await _context.Training.ToListAsync();
        }

        public async Task<Training> GetTrainingAsync(int id)
        {
            return await _context.Training.FindAsync(id);
        }
    }
}
