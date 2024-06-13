using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AbankHW12.Models.Client.BankAccounts
{
    /// <summary>
    /// Абстрактный класс BankAccount, который может быть использован для создания различных типов банковских счетов. 
    /// Каждый счет имеет уникальный ID, имя, цвет (для UI представления или других целей) и баланс, который изменяется через методы Deposit и Withdraw. 
    /// Метод Withdraw особенно важен, так как он содержит проверку на наличие достаточного количества средств перед снятием, предотвращая отрицательный баланс.
    /// </summary>
    public abstract class BankAccount
    {
        // Определение полей класса
        protected int       accountId;                               // ID банковского счёта, доступ только внутри класса и его наследников  
        protected string    accountName;                             // Имя счёта, доступ только внутри класса и его наследников
        protected string    color;                                   // Цвет для UI или других целей, доступ только внутри класса и его наследников     
        protected int       balance = 0;                             // Текущий баланс счета, начальное значение равно 0

        // Свойства для доступа к защищенным полям                   
        public int      AccountId   { get => accountId; }                   // Свойство для получения ID счёта                     
        public string   AccountName { get => accountName; }                 // Свойство для получения имени счёта  
        public string   Color       { get => color; }                       // Свойство для получения цвета  
        public int      Balance     { get => balance; }                     // Свойство для получения текущего баланса 
        public string Info { get { return $"{AccountName}  {Balance}"; } }  // Краткая сводка данных счёта

        // Метод для добавления денег на счет
        public void Put(int amount)
        {
            balance += amount;                              
        }

        // Операция снятия денег со счета
        public void Withdraw(int amount)
        {
            if (amount > balance)                                           // Проверка, больше ли сумма, которую хочет снять пользователь (amount), чем текущий остаток на счету (balance)
                throw new InvalidOperationException("Insufficient funds");  // Недостаточно средств
            balance -= amount;                                              // Если проверка на достаточность средств пройдена успешно (т.е. средств достаточно), то с баланса снимается указанная сумма
        }
    }
}