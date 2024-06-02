using Solid.Core.Models;
using Solid.Core.Repositories;
using Solid.Core.Services;

namespace Solid.Service
{
    public class BankAcountService : IBankAcountService
    {
        private readonly IBankAcountRepository _bankAcountRepository;

        public BankAcountService(IBankAcountRepository bankAcountRepository)
        {
            _bankAcountRepository = bankAcountRepository;
        }

        public async Task<BankAccount> AddAsync(BankAccount bankAccount)
        {
            return await _bankAcountRepository.AddAsync(bankAccount);
        }
        public async Task<BankAccount> UpdateAsync(BankAccount bankAccount)
        {
            return await _bankAcountRepository.UpdateAsync(bankAccount);
        }
        public async Task<List<BankAccount>> GetAllAsync()
        {
            return await _bankAcountRepository.GetAllAsync();
        }
        public async Task<BankAccount> GetByIdAsync(int id)
        {
            return await _bankAcountRepository.GetByIdAsync(id);
        }
        public async Task RemoveAsync(int id)
        {
           await _bankAcountRepository.RemoveAsync(id);
        }
    }
}