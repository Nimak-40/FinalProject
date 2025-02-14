using Achare.Infrastructure;
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _dbContext;

        public PaymentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _dbContext.Payments
                                   .AsNoTracking()
                                   .ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _dbContext.Payments
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Payment>> GetByOrderIdAsync(int orderId)
        {
            return await _dbContext.Payments
                                   .AsNoTracking()
                                   .Where(p => p.OrderId == orderId)
                                   .ToListAsync();
        }

        public async Task AddAsync(Payment payment)
        {
            await _dbContext.Payments.AddAsync(payment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Payment payment)
        {
            var existingPayment = await _dbContext.Payments
                                                 .FirstOrDefaultAsync(p => p.Id == payment.Id);

            if (existingPayment != null)
            {
                existingPayment.Amount = payment.Amount;
                existingPayment.PaymentDate = payment.PaymentDate;
                existingPayment.Method = payment.Method;
                existingPayment.Status = payment.Status;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var payment = await GetByIdAsync(id);
            if (payment != null)
            {
                _dbContext.Payments.Remove(payment);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}