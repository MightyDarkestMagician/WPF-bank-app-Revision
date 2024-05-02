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
    /// <summary>
    /// Класс Client, который моделирует клиента банка. 
    /// Этот класс является ключевым элементом для представления информации о клиенте и управления его банковскими счетами в программе. 
    /// Класс Client управляет двумя типами счетов — депозитным и кредитным. 
    /// 
    /// Инкапсуляция: 
    /// Все поля класса закрыты (private), что предотвращает их непосредственное изменение и позволяет строго контролировать доступ к данным клиента через методы класса.
    /// 
    /// Управление счетами: 
    /// Класс Client может быть использован в любой системе управления клиентами банка, так как он предоставляет все необходимые атрибуты и методы для управления основной информацией о клиенте и его счетами.
    /// Эти счета представлены двумя отдельными объектами, и класс предоставляет методы для их управления, такие как внесение и снятие средств.
    /// 
    /// Гибкость использования:
    /// Класс Client может быть использован в любой системе управления клиентами банка, так как он предоставляет все необходимые атрибуты и методы для управления основной информацией о клиенте и его счетами.
    /// </summary>

    public class Client
    {
        private string  firstName;                          // Имя клиента
        private string  lastName;                           // Изменили имя переменной c sureName
        private string  patronymic;                         // Отчество (вместо fathersName, если приложение для иностранцев, нужно будет изменить на middleName)
        private string  passportNumber;                     // Номер паспорта
        private int     phoneNumber;                        // Телефонный номер


        // Объекты для управления банковскими счетами
        private Deposit depositAccount = new Deposit();     // Депозитный счет
        private Credit creditAccount = new Credit();        // Кредитный  счет


        // Свойства для доступа и управления полями класса
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

        // Конструктор для инициализации клиента с начальными суммами на депозитном и кредитном счетах
        public Client(string firstName, string lastName, string patronymic, int phoneNumber, string passportNumber, int depositAmount, int creditAmount)
            : this(firstName, lastName, patronymic, phoneNumber, passportNumber)
        {
            depositAccount.Deposit(depositAmount);  // Внесение суммы на депозитный счет
            creditAccount.Deposit(creditAmount);    // Внесение суммы на кредитный счет
        }
    }
}
