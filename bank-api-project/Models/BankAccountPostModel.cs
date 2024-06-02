using Solid.Core.Models;

namespace bank_api_project.Models
{
    public class BankAccountPostModel
    {
        public int BankAccountNumber { get; set; }
        public Status Status { get; set; }
        public int Balance { get; set; }
    }
}
