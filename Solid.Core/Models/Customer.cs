namespace Solid.Core.Models
{
    public enum Status { NotActive, Active }
    public class Customer
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Phone { get; set; }
        public int BankAccountNumber { get; set; }
        public Status Status { get;set; }
    }
}
