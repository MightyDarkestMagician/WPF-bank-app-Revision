using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbankHW12.Models.Operator
{
    class Consultant : BankOperator     // Создаем оператора банка
    {
        public Consultant()
        {
            Name = "Consultant";
            Color = "Blue";             // Изменил цвет для большей различимости
        }
    }
}
