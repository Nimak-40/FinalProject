﻿using Achare.Infrastructure;
using App.src.Domain.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders
                                   .AsNoTracking()
                                   .Include(o => o.Customer)
                                   .Include(o => o.Service)
                                   .Include(o => o.Payments)
                                   .Include(o => o.Reviews)
                                   .Include(o => o.ChatMessages)
                                   .Include(o => o.OrderRequests)
                                   .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _dbContext.Orders
                                   .AsNoTracking()
                                   .Include(o => o.Customer)
                                   .Include(o => o.Service)
                                   .Include(o => o.Payments)
                                   .Include(o => o.Reviews)
                                   .Include(o => o.ChatMessages)
                                   .Include(o => o.OrderRequests)
                                   .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetByCustomerIdAsync(int customerId)
        {
            return await _dbContext.Orders
                                   .AsNoTracking()
                                   .Where(o => o.CustomerId == customerId)
                                   .Include(o => o.Service)
                                   .ToListAsync();
        }

        public async Task<List<Order>> GetByServiceIdAsync(int serviceId)
        {
            return await _dbContext.Orders
                                   .AsNoTracking()
                                   .Where(o => o.ServiceId == serviceId)
                                   .Include(o => o.Customer)
                                   .ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            var existingOrder = await _dbContext.Orders
                                                 .FirstOrDefaultAsync(o => o.Id == order.Id);

            if (existingOrder != null)
            {
                existingOrder.Status = order.Status;
                existingOrder.TotalAmount = order.TotalAmount;
                existingOrder.ScheduledDate = order.ScheduledDate;
                existingOrder.OrderDate = order.OrderDate;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var order = await GetByIdAsync(id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}