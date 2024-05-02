using AbankHW12.Models.Client;
using AbankHW12.Models.Operator;
using AbankHW12.Views;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace AbankHW12.ViewModels
{
    /// <summary>
    /// ViewModel for the main window ("Shell") of the application.
    /// </summary>
    internal class ShellViewModel : Screen
    {
        // Раздел переменных и состояний
        private BankOperator bankOperator = new Consultant();                   // Изменил название для соответствия стилю CamelCase
        private string userInput = "password";                                  // Переименовано для ясности: что это ввод пользователя
        private string actualPassword = "pass";                                 // Ясное отражение назначения переменной
        private bool canModify = true;                                          // Более понятное название
        private Client selectedClient;                                          // Текущий выбранный клиент

        // Управление видимостью интерфейсов в зависимости от роли пользователя
        private Visibility superUserInterface = Visibility.Collapsed;           // Переименовано для ясности
        private Visibility ordinaryInterface = Visibility.Visible;              // Переименовано для ясности

        // Свойства для привязки и уведомления об изменениях
        public Visibility SuperUserInterface
        {
            get { return superUserInterface; }
            set { superUserInterface = value; NotifyOfPropertyChange(() => SuperUserInterface); }
        }
        public Visibility OrdinaryInterface
        {
            get { return ordinaryInterface; }
            set { ordinaryInterface = value; NotifyOfPropertyChange(() => OrdinaryInterface); }
        }

        // Коллекция клиентов с уведомлением об изменениях
        private ObservableCollection<Client> clients = new ObservableCollection<Client>
         {
            new Client("John", "Doe", "John Sr.", 123456789, "ABC123", 1000, 500),
            new Client("Jane", "Smith", "Jane Sr.", 987654321, "XYZ789", 2000, 750),
            new Client("Davie", "Homel", "Bob", 567183545, "MOE703", 10000, 0),
            new Client("Jane", "Smith", "Locky", 584247681, "BSY723", 200000, 782),
            new Client("John", "Doe", "John Sr.", 123456789, "ABC123", 1000, 500),
            new Client("Jane", "Smith", "Jane Sr.", 987654321, "XYZ789", 2000, 750),
            new Client("Davie", "Homel", "Bob", 567183545, "MOE703", 10000, 0),
            new Client("Jane", "Smith", "Locky", 584247681, "BSY723", 200000, 782),
            new Client("John", "Doe", "John Sr.", 123456789, "ABC123", 1000, 500),
            new Client("Jane", "Smith", "Jane Sr.", 987654321, "XYZ789", 2000, 750),
            new Client("Davie", "Homel", "Bob", 567183545, "MOE703", 10000, 0),
            new Client("Jane", "Smith", "Locky", 584247681, "BSY723", 200000, 782),
            new Client("John", "Doe", "John Sr.", 123456789, "ABC123", 1000, 500),
            new Client("Jane", "Smith", "Jane Sr.", 987654321, "XYZ789", 2000, 750),
            new Client("Davie", "Homel", "Bob", 567183545, "MOE703", 10000, 0),
            new Client("Jane", "Smith", "Locky", 584247681, "BSY723", 200000, 782),
        };

        public ObservableCollection<Client> Clients
        {
            get { return clients; }
            set { clients = value; NotifyOfPropertyChange(() => Clients); }                     
        }

        public Client SelectedClient
        {
            get { return selectedClient; }
            set { selectedClient = value; NotifyOfPropertyChange(() => SelectedClient); }
        }

        public BankOperator Operator                                                            // измененно на Operator c Op  
        {
            get { return bankOperator; }                                                        // измененно на bankOperator c BANKo 
            set { bankOperator = value; NotifyOfPropertyChange(() => Operator); }
        }
            
        public string UserInput                                                                 // измененно на UserInput с input 
        {
            get { return userInput; }
            set { userInput = value; NotifyOfPropertyChange(() => UserInput); }
        }

        public bool CanModify                                                                   // измененно на CanModify с CanChange 
        {
            get { return canModify; }
            set { canModify = value; NotifyOfPropertyChange(() => CanModify); }
        }

        // Методы для логики изменения состояния приложения
        public void ChangeBankOperator()
        {
            if (Operator.IsSuperUser)                               // В BankOperator измененно свойство SU на IsSuperUser
            {
                Operator = new Consultant();
                PlayBeepSound();
                UserInput = "";

                SuperUserInterface = Visibility.Collapsed;          // Изменено с SUInter
                OrdinaryInterface = Visibility.Visible;             // Изменено с OInter 

                CanModify = true;                                   // Изменение с CanChange  
            }
            else
            {
                if (UserInput == actualPassword)
                {
                    Operator = new Manager();
                    PlayBeepSound();
                    UserInput = "";

                    SuperUserInterface = Visibility.Visible;         // Изменено с SUInter
                    OrdinaryInterface = Visibility.Collapsed;        // Изменено с OInter 

                    CanModify = false;                               // Изменение с CanChange  
                }
                else
                {
                    UserInput = "";
                    Console.Beep(100, 40); // Error beep
                }
            }
        }

        /// <summary>
        /// Plays a beep sound to indicate a change in state or an action. Добавлен отдельным методом. 
        /// </summary>
        private void PlayBeepSound()
        {
            Console.Beep(150, 100); // Higher pitch beep
            Console.Beep(100, 100); // Lower pitch beep
        }

        /// <summary>
        /// Adds a new blank client to the collection.
        /// </summary>
        public void AddClient()
        {
            Clients.Add(new Client(null, null, null, 0, null));
            SelectedClient = Clients.Last();
        }
    }
}
