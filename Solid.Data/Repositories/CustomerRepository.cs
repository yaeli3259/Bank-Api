using Microsoft.EntityFrameworkCore;
using Solid.Core.Models;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly DataContext _dataCustomer;

        public CustomerRepository(DataContext dateCustomer)
        {
            _dataCustomer = dateCustomer;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _dataCustomer.Customers.ToListAsync();
        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _dataCustomer.Customers.FirstAsync(x => x.Id == id);
        }
        public async Task<Customer> AddAsync(Customer customer)
        {
            _dataCustomer.Customers.Add(customer);
            await _dataCustomer.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        { 
            var existCustomer = await GetByIdAsync(customer.Id);
            _dataCustomer.Entry(existCustomer).CurrentValues.SetValues(customer);
            await _dataCustomer.SaveChangesAsync();
            return existCustomer;
        }

        public async Task RemoveAsync(int id)
        {
            Customer temp = await GetByIdAsync(id);
            if (temp != null)
            {
                _dataCustomer.Customers.Remove(temp);
                _dataCustomer.SaveChanges();
            }
        }
    }
}
