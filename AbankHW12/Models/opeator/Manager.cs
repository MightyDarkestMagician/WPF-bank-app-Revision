using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbankHW12.Models.opeator
{
    class Manager : BankOperator //создаём менеджера
    {
        public Manager() { name = "Manager"; super_user = true; color = "red"; }
    }
}
