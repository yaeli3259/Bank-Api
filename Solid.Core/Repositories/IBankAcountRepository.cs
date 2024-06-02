using Solid.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IBankAcountRepository
    {
        Task<List<BankAccount>> GetAllAsync();
        Task<BankAccount> GetByIdAsync(int id);
        Task<BankAccount> AddAsync(BankAccount bankAccount);
        Task<BankAccount> UpdateAsync(BankAccount value);
        Task RemoveAsync(int id);
    }
}
