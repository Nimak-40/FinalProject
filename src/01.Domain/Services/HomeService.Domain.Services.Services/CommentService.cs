using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Contracts.Service;
using App.src.Domain.Core.Dtos.Categories;

namespace App.Domain.Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentDto>> GetAllAsync(int pageNumber, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAllComments(pageNumber, cancellationToken);
            return comments.Select(c => new GetCommentDto
            {
                Id = c.Id,
                Message = c.Message,
                CustomerId = c.CustomerId.Value,
                Status = c.Status,
                CreateAt = c.CreateAt,
                SentDate = c.SentDate
            }).ToList();
        }

        public async Task<int> GetTotalCount(CancellationToken cancellationToken)
        {
            return await _commentRepository.GetTotalCount(cancellationToken);
        }

        public async Task ApproveCommentAsync(int id, CancellationToken cancellationToken)
        {
            await _commentRepository.AcceptComment(id, cancellationToken);
        }

        public async Task RejectCommentAsync(int id, CancellationToken cancellationToken)
        {
            await _commentRepository.RejectComment(id, cancellationToken);
        }
    }

}
