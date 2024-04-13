using AbankHW12.Models.Client.BanckAcconts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AbankHW12.Models.Client
{
    class Client 
    {
        private string name;
        private string sureName;
        private string fathersName;
        private string passportNum;

        private Deposit deposit = new Deposit();
        private Credit credit = new Credit();

        public string Name { get { return this.name; }set { this.name = value; } }
        public string Surename { get { return this.sureName; }set { this.sureName = value; } }
        public string FathersName { get { return this.fathersName; } set { this.fathersName = value; } }
        public string PassportNum { get { return this.passportNum; } set { this.passportNum = value; } }
        public int PhoneNum { get; set; }
        public Deposit Deposit { get { return this.deposit; } }
        public Credit Credit { get { return this.credit; } }


        public Client(string Name, string Surename, string FathersName, int Phone, string Passport)
        {
            
        }
        public Client(string Name, string Surename, string FathersName, int Phone, string Passport, int val1, int val2)
        {
            this.name = Name;
            this.sureName = Surename;
            this.fathersName = FathersName;
            this.PhoneNum = Phone;
            this.passportNum = Passport;
            this.deposit.put(val1);
            this.credit.put(val2);

        }


    }
}
