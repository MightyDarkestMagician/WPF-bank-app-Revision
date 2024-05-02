using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AbankHW12.Models.Client.BankAccounts
{
    public class Credit : BankAccount
    {
        public Credit()
        {
            accountName = "Credit Account";
            color = "Red";
        }
    }
}
