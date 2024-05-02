using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbankHW12.Models.Operator
{
    class Manager : BankOperator    // Creating manager
    {
        public Manager()
        {
            Name = "Manager";
            IsSuperUser = true;
            Color = "Red";
        }
    }
}
