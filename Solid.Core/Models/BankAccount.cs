using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Models
{
    public class BankAccount
    {
        public int BankAccountNumber { get; set; }
        public int Id { get;set; }
        public Status Status { get; set; }
        public int Balance { get;set; }
        public List<BankOperation> withdrawals { get; set; }
        public List<BankOperation> deposits { get; set; }
    }
}
