using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AbankHW12.Models.Operator
{
    abstract class BankOperator                 // Добавление "операторов", можно добавить больше инструментария
    {
        private bool isSuperUser = false;       // По умолчанию выключено
        private string name = "Default";
        private string color = "Black";

        public string Name      { get => name; protected set => name = value; }
        public string Color     { get => color; protected set => color = value; }
        public bool IsSuperUser { get => isSuperUser; protected set => isSuperUser = value; }
    }
}