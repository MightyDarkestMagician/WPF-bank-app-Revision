using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbankHW12.Models.Client.BanckAcconts
{
    abstract class BankAccount //класс для создания банковских счетов (название говорит само за себя)
    {
        protected int id; //нужно для перевода, почти уникальное число 
        protected string name;// имя депозитный или кредитный
        protected string color; //будет два цвета синий-депозитный, красный - кредитный
        protected int value=0;// ну тут ясно, денежки на счету

        public int ID { get {  return ID; }  }
        public string Name { get { return name; } }
        public string Color { get { return color; } }
        public int Value { get { return value; } }

        public void put(int value)
        {
            this.value += value;
        }

        public void withdraw(int value)
        {
            this.value -= value;
        }
    }
}
