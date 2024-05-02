using AbankHW12.Models.Client.BankAccounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AbankHW12.Models.Client
{
    public class Client
    {
        private string  firstName;
        private string  lastName;            // Изменили имя переменной c sureName
        private string  patronymic;          // Отчество (вместо fathersName, если приложение для иностранцев, нужно будет изменить на middleName)
        private string  passportNumber;
        private int     phoneNumber;

        private Deposit depositAccount = new Deposit();
        private Credit creditAccount = new Credit();

        public string   FirstName       { get => firstName;      set => firstName = value; }
        public string   LastName        { get => lastName;       set => lastName = value; }                    // Изменили свойство
        public string   Patronymic      { get => patronymic;     set => patronymic = value; }                  // Используем для отчества 
        public string   PassportNumber  { get => passportNumber; set => passportNumber = value; }       
        public int      PhoneNumber     { get => phoneNumber;    set => phoneNumber = value; }
        public Deposit  DepositAccount  { get => depositAccount; }
        public Credit   CreditAccount   { get => creditAccount; }

        public Client(string firstName, string lastName, string patronymic, int phoneNumber, string passportNumber)
        {
            this.firstName      = firstName;                // Исправлено для соответствия новому имени переменной
            this.lastName       = lastName;                 // Исправлено для соответствия новому имени переменной
            this.patronymic     = patronymic;               // Исправлено для соответствия новому имени переменной
            this.phoneNumber    = phoneNumber;              // Исправлено для соответствия новому имени переменной
            this.passportNumber = passportNumber;           // Исправлено для соответствия новому имени переменной
        }

        public Client(string firstName, string lastName, string patronymic, int phoneNumber, string passportNumber, int depositAmount, int creditAmount)
            : this(firstName, lastName, patronymic, phoneNumber, passportNumber)
        {
            depositAccount.Deposit(depositAmount);
            creditAccount.Deposit(creditAmount);
        }
    }
}
