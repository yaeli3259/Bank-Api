using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_api_project.Models
{
    public class BankOperationPostModel
    {
        public DateTime Date { get; set; }
        public int Sum { get; set; }
    }
}
