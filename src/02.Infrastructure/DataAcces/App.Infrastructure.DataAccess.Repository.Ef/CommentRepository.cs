using Achare.Infrastructure;
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _dbContext;

        public CommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _dbContext.Comments
                                   .AsNoTracking()
                                   .Include(c => c.Order)
                                   .ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _dbContext.Comments
                                   .AsNoTracking()
                                   .Include(c => c.Order)
                                   .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Comment>> GetByOrderIdAsync(int orderId)
        {
            return await _dbContext.Comments
                                   .AsNoTracking()
                                   .Where(c => c.OrderId == orderId)
                                   .ToListAsync();
        }

        public async Task AddAsync(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            var existingComment = await _dbContext.Comments.FindAsync(comment.Id);

            if (existingComment != null)
            {
                _dbContext.Entry(existingComment).CurrentValues.SetValues(comment);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await _dbContext.Comments.FindAsync(id);
            if (comment != null)
            {
                _dbContext.Comments.Remove(comment);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
