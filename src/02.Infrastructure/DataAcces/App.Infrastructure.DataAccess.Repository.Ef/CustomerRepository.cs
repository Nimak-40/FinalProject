using Achare.Infrastructure;
using App.src.Domain.Core.Contracts.Repositories;
using App.src.Domain.Core.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository.Ef
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _dbContext.Customers
                                   .AsNoTracking()
                                   .Include(c => c.Orders)
                                   .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _dbContext.Customers
                                   .AsNoTracking()
                                   .Include(c => c.Orders)
                                   .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer?> GetByUsernameAsync(string username)
        {
            return await _dbContext.Customers
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(c => c.Username == username);
        }

        public async Task AddAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            var existingCustomer = await _dbContext.Customers
                                                     .FirstOrDefaultAsync(c => c.Id == customer.Id);

            if (existingCustomer != null)
            {
                existingCustomer.PreferredAddress = customer.PreferredAddress;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await GetByIdAsync(id);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}