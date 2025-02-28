using Achare.Infrastructure;
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Entities.UserEntities;
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
                                   .Include(s => s.User) // اضافه کردن User
                                   .ToListAsync();
        }

        public async Task<Specialist?> GetByIdAsync(int id)
        {
            return await _dbContext.Specialists
                                   .AsNoTracking()
                                   .Include(s => s.User) // اضافه کردن User
                                   .FirstOrDefaultAsync(s => s.UserId == id);
        }

        public async Task<Specialist?> GetByUsernameAsync(string username)
        {
            return await _dbContext.Specialists
                                   .AsNoTracking()
                                   .Include(s => s.User) // اضافه کردن User
                                   .FirstOrDefaultAsync(s => s.User != null && s.User.UserName == username);
        }

        public async Task AddAsync(Specialist specialist)
        {
            await _dbContext.Specialists.AddAsync(specialist);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Specialist specialist)
        {
            var existingSpecialist = await _dbContext.Specialists
                                                     .Include(s => s.User) // اضافه کردن User
                                                     .FirstOrDefaultAsync(s => s.UserId == specialist.UserId);

            if (existingSpecialist != null && existingSpecialist.User != null)
            {
                // بروزرسانی اطلاعات User
                existingSpecialist.User.UserName = specialist.User.UserName;
                existingSpecialist.User.Email = specialist.User.Email;
                existingSpecialist.User.PasswordHash = specialist.User.PasswordHash;
                existingSpecialist.User.FirstName = specialist.User.FirstName;
                existingSpecialist.User.LastName = specialist.User.LastName;
                existingSpecialist.User.ImagePath = specialist.User.ImagePath;

                // بروزرسانی اطلاعات Specialist
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
