using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>
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
            get => first_name;
            set => first_name = value;
        }

        public string LastName
        {
            get => last_name;
            set => last_name = value;
        }

        public string EMail
        {
            get => e_mail;
            set => e_mail = value;
        }

        public string MobilePhone
        {
            get => mobile_phone;
            set => mobile_phone = value;
        }

        public string WorkPhone
        {
            get => work_phone;
            set => work_phone = value;
        }

        public string MainAddress
        {
            get => main_address;
            set => main_address = value;
        }

        public string SecondAddress
        {
            get => second_address;
            set => second_address = value;
        }

        public bool Equals(ContactData other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            if (FirstName == other.FirstName && LastName == other.LastName) return true;
            else
                return false;
        }
    }
}