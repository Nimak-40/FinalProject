
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Entities.BaseEntities;
using App.src.Domain.Core.Enums;
using App.src.Infrastructure.DbContext;
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

        public async Task<List<Comment>> GetAllComments(int pageNumber, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_dbContext.Comments
                .Skip((pageNumber - 1) * 10)
                .Take(10)
                .ToList());
        }

        public async Task<int> GetTotalCount(CancellationToken cancellationToken)
        {
            return await _dbContext.Comments.CountAsync(cancellationToken);
        }

        public async Task AcceptComment(int commentId, CancellationToken cancellationToken)
        {
            var comment = _dbContext.Comments.FirstOrDefault(c => c.Id == commentId);
            if (comment != null)
            {
                comment.Status = CommentStatusEnum.Accepted;
            }
            await Task.CompletedTask;
        }

        public async Task RejectComment(int commentId, CancellationToken cancellationToken)
        {
            var comment = _dbContext.Comments.FirstOrDefault(c => c.Id == commentId);
            if (comment != null)
            {
                comment.Status = CommentStatusEnum.Rejected;
            }
            await Task.CompletedTask;
        }
    }
}
