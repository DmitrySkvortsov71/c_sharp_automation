using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();

            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int index, ContactData newContactData)
        {
            manager.Navigator.OpenHomePage();

            if (GetContactsQuantityOnPage() == 0) Create(new ContactData("", "", ""));

            InitContactModification(index);
            FillContactForm(newContactData);
            SubmitContactModification();

            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            manager.Navigator.OpenHomePage();

            var contacts = GetContactsQuantityOnPage();
            if (GetContactsQuantityOnPage() == 0) Create(new ContactData("", "", ""));

            SelectContact(index);
            SubmitContactDeletion();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public int GetContactsQuantityOnPage()
        {
            // -1 for "Select All" (it always present on Page)
            return driver.FindElements(By.CssSelector("input[id]")).Count - 1;
        }

        public ContactHelper SubmitContactDeletion()
        {
            driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();

            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElements(By.CssSelector("input[id]"))[index - 1].Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.CssSelector("a[href^='edit.php?id=']"))[index - 1].Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            // mandatory parameters
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("email"), contact.EMail);

            // additional parameters
            if (contact.MainAddress != "") Type(By.Name("address"), contact.MainAddress);

            if (contact.MobilePhone != "") Type(By.Name("mobile"), contact.MobilePhone);

            if (contact.WorkPhone != "") Type(By.Name("work"), contact.WorkPhone);

            if (contact.SecondAddress != "") Type(By.Name("address2"), contact.SecondAddress);
            return this;
        }
    }
}