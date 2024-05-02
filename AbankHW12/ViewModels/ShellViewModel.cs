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
    /// ViewModel главного окна приложения, управляющий логикой взаимодействия с пользовательским интерфейсом
    /// и поддержанием состояния приложения. Эта модель представления обрабатывает пользовательский ввод,
    /// контролирует видимость интерфейса в зависимости от роли пользователя и управляет данными клиентов.
    /// 
    /// Наследование:
    /// ShellViewModel наследуется от класса Screen, что обеспечивает базовую инфраструктуру для реализации
    /// моделей представления в MVVM паттерне.
    /// 
    /// Основные компоненты и их функции:
    /// - bankOperator: Хранит текущего оператора банка, может быть менеджером или консультантом.
    /// - userInput и actualPassword: Строки для хранения ввода пользователя и проверки пароля.
    /// - canModify: Флаг, позволяющий или запрещающий изменения в пользовательском интерфейсе.
    /// - selectedClient: Текущий выбранный клиент, данные которого отображаются и редактируются.
    /// - clients: Коллекция клиентов, с возможностью уведомления об изменениях для обновления интерфейса.
    /// 
    /// Управление видимостью интерфейса:
    /// - SuperUserInterface и OrdinaryInterface: Свойства для контроля видимости элементов интерфейса,
    ///   в зависимости от того, обладает ли текущий пользователь правами суперпользователя.
    /// 
    /// Методы управления состоянием:
    /// - ChangeBankOperator: Метод для смены роли оператора в зависимости от ввода пользователя,
    ///   с дополнительной звуковой сигнализацией для подтверждения действий.
    /// - AddClient: Добавление нового клиента в коллекцию, что позволяет начать ввод данных непосредственно
    ///   через пользовательский интерфейс.
    /// 
    /// Пример использования:
    /// Эта модель представления используется в основном окне приложения для управления взаимодействием с клиентской базой,
    /// редактирования и просмотра данных клиентов, а также управления доступом к различным функциональным частям интерфейса
    /// на основе уровня доступа текущего пользователя.
    /// </summary>

    internal class ShellViewModel : Screen
    {
        // Описание переменных с аннотациями о их назначении в коде
        private BankOperator bankOperator = new Consultant();           // Оператор по умолчанию - Консультант
        private string userInput = "password";                          // Переменная для хранения ввода пользователя (изменен с input)
        private string actualPassword = "pass";                         // Реальный пароль для доступа к функциям суперпользователя
        private bool canModify = true;                                  // Флаг разрешения на изменения в интерфейсе (изменен с CanChange)
        private Client selectedClient;                                  // Выбранный клиент для отображения/редактирования данных

        // Управление видимостью элементов интерфейса
        private Visibility superUserInterface = Visibility.Collapsed;   // Интерфейс суперпользователя скрыт по умолчанию
        private Visibility ordinaryInterface = Visibility.Visible;      // Обычный интерфейс виден по умолчанию

        // Свойства, связанные с элементами управления в интерфейсе
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

        /// <summary> Свойство Clients
        /// Тип: ObservableCollection<Client>
        /// Это коллекция, которая хранит объекты Client. 
        /// ObservableCollection автоматически генерирует уведомления при добавлении, удалении элементов или обновлении 
        /// всей коллекции, что полезно для обновления пользовательского интерфейса при изменении данных.
        /// 
        /// Getter: Возвращает текущее значение приватного поля clients.
        /// Setter: Устанавливает новое значение для clients и отправляет уведомление об изменении свойства, 
        /// что позволяет обновить привязанные элементы интерфейса, зависящие от этого свойства.
        /// </summary>
        public ObservableCollection<Client> Clients
        {
            /// <summary> Метод NotifyOfPropertyChange
            /// Метод NotifyOfPropertyChange() вызывается в каждом сеттере и является частью механизма уведомлений о изменении свойства, 
            /// который используется для автоматического обновления пользовательского интерфейса при изменении данных.
            /// Это позволяет динамически реагировать на изменения данных без необходимости ручного обновления элементов интерфейса.
            /// </summary>
            get { return clients; }
            set { clients = value; NotifyOfPropertyChange(() => Clients); }
        }

        /// <summary> Свойство SelectedClient
        /// Тип: Client
        /// Содержит ссылку на выбранного клиента в пользовательском интерфейсе.
        /// 
        /// Getter: Возвращает текущего выбранного клиента.
        /// Setter: Устанавливает нового выбранного клиента и оповещает систему о необходимости обновления интерфейса.
        /// </summary>
        public Client SelectedClient
        {
            get { return selectedClient; }
            set { selectedClient = value; NotifyOfPropertyChange(() => SelectedClient); }
        }

        /// <summary> Свойство Operator
        /// Тип: BankOperator
        /// Хранит информацию о текущем операторе банка (например, менеджер или консультант).
        /// 
        /// Getter: Возвращает текущее значение bankOperator.
        /// Setter: Устанавливает новое значение для bankOperator и генерирует уведомление о его изменении.
        /// </summary>
        public BankOperator Operator
        {
            get { return bankOperator; }
            set { bankOperator = value; NotifyOfPropertyChange(() => Operator); }
        }

        /// <summary> Свойство UserInput
        /// Тип: string
        /// Содержит ввод пользователя, который может использоваться, например, для аутентификации.
        /// 
        /// Getter: Возвращает текущее значение ввода пользователя.
        /// Setter: Устанавливает новое значение ввода пользователя и оповещает об изменении.
        /// </summary>
        public string UserInput // изменен с input
        {
            get { return userInput; }
            set { userInput = value; NotifyOfPropertyChange(() => UserInput); }
        }

        /// <summary>Свойство CanModify
        /// Тип: bool
        /// Флаг, указывающий, может ли пользователь изменять данные.
        /// 
        /// Getter: Возвращает, разрешено ли изменение данных.
        /// Setter: Устанавливает новое значение разрешения и оповещает об изменении.
        /// </summary>
        public bool CanModify // изменен с CanChange
        {
            get { return canModify; }
            set { canModify = value; NotifyOfPropertyChange(() => CanModify); }
        }




        // Методы для изменения состояния и реакции на пользовательский ввод
        public void ChangeBankOperator()
        {
            if (Operator.IsSuperUser)
            {
                Operator = new Consultant();
                PlayBeepSound();
                UserInput = "";
                SuperUserInterface = Visibility.Collapsed;
                OrdinaryInterface = Visibility.Visible;
                CanModify = true;
            }
            else
            {
                if (UserInput == actualPassword)
                {
                    Operator = new Manager();
                    PlayBeepSound();
                    UserInput = "";
                    SuperUserInterface = Visibility.Visible;
                    OrdinaryInterface = Visibility.Collapsed;
                    CanModify = false;
                }
                else
                {
                    UserInput = "";
                    Console.Beep(100, 40); // Сигнал ошибки при неверном вводе
                }
            }
        }

        /// <summary>
        /// Воспроизведение звукового сигнала при изменении состояния или выполнении действия.
        /// </summary>
        private void PlayBeepSound()
        {
            Console.Beep(150, 100); // Высокий тон
            Console.Beep(100, 100); // Низкий тон
        }

        /// <summary>
        /// Добавление нового клиента в коллекцию, что позволяет начать ввод данных прямо в интерфейсе.
        /// </summary>
        public void AddClient()
        {
            Clients.Add(new Client(null, null, null, 0, null));
            SelectedClient = Clients.Last();
        }
    }
}

