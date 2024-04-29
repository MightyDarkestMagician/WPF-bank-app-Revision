using AbankHW12.Models.Client;
using AbankHW12.Models.opeator;
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
    internal class ShellViewModel : Screen //   View Model
    {
        #region переменные, и прочие данные 

        private BankOperator BANKo = new Consultant();
        private string Input = "password";//User input
        private string password = "pass"; // actual password
        private bool canchange = true;
        private Client selectedClient;

        private Visibility SUInteface = Visibility.Collapsed;
        private Visibility OrdinaryInteface = Visibility.Visible;

        public Visibility SUInter { get { return SUInteface; } set{ SUInteface = value; NotifyOfPropertyChange(() => SUInter); } }
        public Visibility OInter { get { return OrdinaryInteface; }set{ OrdinaryInteface = value; NotifyOfPropertyChange(() => OInter); } }

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

        public ObservableCollection<Client> Clients {  get { return clients; } set { Clients = value; NotifyOfPropertyChange(() => Clients); } }

        public Client SelectedClient {  get { return selectedClient; } set { selectedClient = value; NotifyOfPropertyChange(() => SelectedClient); } }
        public BankOperator Op { get { return BANKo; } set { BANKo = value; NotifyOfPropertyChange(() => Op); } }
        public string input { get { return Input; } set { Input = value; NotifyOfPropertyChange(() => input); } }

        public bool CanChange {  get { return canchange; } set {canchange=value; NotifyOfPropertyChange(() => CanChange); } }

        
        #endregion

        public void ChangeBankOperator()
        {
            if (Op.SU)
            {
                Op = new Consultant();
                Console.Beep(150, 100); // ха-ха программа делвет бип-бип
                Console.Beep(100, 100);
                input = "";

                SUInter = Visibility.Collapsed;
                OInter = Visibility.Visible;

                CanChange = true;
                
            }
            else
            {
                if (Input == password)
                {
                    Op = new Manager();
                    Console.Beep(100, 100);
                    Console.Beep(150, 100);
                    input = "";

                    SUInter = Visibility.Visible;
                    OInter = Visibility.Collapsed;

                    CanChange = false;

                }

                else
                {
                    input = "";
                    Console.Beep(100, 40);

                }
                
            }
        }

        public void AddClient()
        {
            clients.Add(new Client(null, null, null, 0, null));

            SelectedClient = clients.Last();
        }
    }
}
