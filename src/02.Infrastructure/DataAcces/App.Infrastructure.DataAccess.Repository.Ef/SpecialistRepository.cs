using Achare.Infrastructure;
using Achare.src.Domain.Core.Entities;
using App.src.Domain.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class SpecialistRepository : ISpecialistRepository
    {
        private readonly AppDbContext _dbContext;

        public SpecialistRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Specialist>> GetAllAsync()
        {
            return await _dbContext.Specialists
                                   .AsNoTracking()
                                   .ToListAsync();
        }

        public async Task<Specialist?> GetByIdAsync(int id)
        {
            return await _dbContext.Specialists
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Specialist?> GetByUsernameAsync(string username)
        {
            return await _dbContext.Specialists
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(s => s.Username == username);
        }

        public async Task AddAsync(Specialist specialist)
        {
            await _dbContext.Specialists.AddAsync(specialist);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Specialist specialist)
        {
            var existingSpecialist = await _dbContext.Specialists
                                                      .FirstOrDefaultAsync(s => s.Id == specialist.Id);

            if (existingSpecialist != null)
            {
                existingSpecialist.Username = specialist.Username;
                existingSpecialist.Email = specialist.Email;
                existingSpecialist.PasswordHash = specialist.PasswordHash;
                existingSpecialist.FirstName = specialist.FirstName;
                existingSpecialist.LastName = specialist.LastName;
                existingSpecialist.ProfilePicture = specialist.ProfilePicture;
                existingSpecialist.CityId = specialist.CityId;
                existingSpecialist.City = specialist.City;
                existingSpecialist.Specialty = specialist.Specialty;
                existingSpecialist.Resume = specialist.Resume;
                existingSpecialist.Certificates = specialist.Certificates;
                existingSpecialist.Rating = specialist.Rating;
                existingSpecialist.IsAvailable = specialist.IsAvailable;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var specialist = await GetByIdAsync(id);
            if (specialist != null)
            {
                _dbContext.Specialists.Remove(specialist);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
