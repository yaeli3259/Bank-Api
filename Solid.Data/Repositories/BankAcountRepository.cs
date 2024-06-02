using Solid.Core.Models;
using Microsoft.EntityFrameworkCore;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class BankAcountRepository : IBankAcountRepository
    {
        private readonly DataContext _dataBankAcount;

        public BankAcountRepository(DataContext BankAcount)
        {
            _dataBankAcount = BankAcount;
        }
        public async Task<List<BankAccount>> GetAllAsync()
        {
            return await _dataBankAcount.BankAccounts.ToListAsync();
        }
        public async Task<BankAccount> GetByIdAsync(int id)
        {
            return await _dataBankAcount.BankAccounts.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<BankAccount> AddAsync(BankAccount bankAccount)
        {
            _dataBankAcount.BankAccounts.Add(bankAccount);
             await _dataBankAcount.SaveChangesAsync();
            return bankAccount;
        }

        //public async Task<BankAccount> UpdateAsync(BankAccount bankAccount)
        //{
        //    var existBankAccount = await GetByIdAsync(bankAccount.Id);
        //    _dataBankAcount.Entry(existBankAccount).CurrentValues.SetValues(bankAccount);
        //    await _dataBankAcount.SaveChangesAsync();
        //    return existBankAccount;
        //}
        public async Task<BankAccount> UpdateAsync(BankAccount bankAccount)
        {
            var existBankAccount = await GetByIdAsync(bankAccount.Id);
            if (existBankAccount == null)
            {
                throw new InvalidOperationException($"Bank account with ID {bankAccount.Id} not found.");
            }

            _dataBankAcount.Entry(existBankAccount).CurrentValues.SetValues(bankAccount);
            await _dataBankAcount.SaveChangesAsync();
            return existBankAccount;
        }

        public async Task RemoveAsync(int id)
        {
            var existBankAccount = await GetByIdAsync(id);
            if (existBankAccount != null)
            {
                existBankAccount.Status = Status.NotActive;
                await _dataBankAcount.SaveChangesAsync();
            }
        }
    }
}
