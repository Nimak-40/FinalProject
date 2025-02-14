using Achare.Infrastructure;
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _dbContext;

        public ReviewRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _dbContext.Reviews
                                   .AsNoTracking()
                                   .ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _dbContext.Reviews
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Review>> GetByOrderIdAsync(int orderId)
        {
            return await _dbContext.Reviews
                                   .AsNoTracking()
                                   .Where(r => r.OrderId == orderId)
                                   .ToListAsync();
        }

        public async Task AddAsync(Review review)
        {
            await _dbContext.Reviews.AddAsync(review);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Review review)
        {
            var existingReview = await _dbContext.Reviews
                                                 .FirstOrDefaultAsync(r => r.Id == review.Id);

            if (existingReview != null)
            {
                existingReview.Rating = review.Rating;
                existingReview.Comment = review.Comment;
                existingReview.ReviewDate = review.ReviewDate;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var review = await GetByIdAsync(id);
            if (review != null)
            {
                _dbContext.Reviews.Remove(review);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}