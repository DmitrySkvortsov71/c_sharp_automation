using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests: TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));

            InitContactCreation();

            ContactData contact = new ContactData("werty", "qwerty", "werty.qwert@gmail.com")
            {
                MobilePhone = "+711111111",
                MainAddress = "kjhdsfkhjskdhjf"
            };
            FillContactForm(contact);
            SubmitContactCreation();

            OpenHomePage();
            Logout();
        }
    }
}