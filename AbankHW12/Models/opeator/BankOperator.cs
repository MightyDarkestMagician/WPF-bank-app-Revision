using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbankHW12.Models.opeator
{
    abstract class BankOperator //добавление "операторов", можно добавить больше инструментария
    {
        protected bool super_user = false; //по умолчанию выключено

        protected string name = "gg"; 
        protected string color = "black";

        public string Name { get { return this.name; } }
        public string Color { get { return this.color; } }
        public bool SU {  get { return this.super_user; } }
    }
}
