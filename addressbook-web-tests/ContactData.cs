using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string first_name;
        private string last_name;
        private string e_mail;
        private string mobile_phone = "";
        private string work_phone = "";
        private string main_address = "";
        private string second_address = "";

        public ContactData(string first_name, string last_name, string e_mail)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.e_mail = e_mail;
        }

        public string FirstName
        {
            get
            {
                return first_name;
            }
            set
            {
                first_name = value;
            }
        }

        public string LastName
        {
            get
            {
                return last_name;
            }
            set
            {
                last_name = value;
            }
        }

        public string EMail
        {
            get
            {
                return e_mail;
            }
            set
            {
                e_mail = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return mobile_phone;
            }
            set
            {
                mobile_phone = value;
            }
        }

        public string WorkPhone
        {
            get
            {
                return work_phone;
            }
            set
            {
                work_phone = value;
            }
        }

        public string MainAddress
        {
            get
            {
                return main_address;
            }
            set
            {
                main_address = value;
            }
        }

        public string SecondAddress
        {
            get
            {
                return second_address;
            }
            set
            {
                second_address = value;
            }
        }
    }
}
