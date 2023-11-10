using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests: TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("werty", "qwerty", "werty.qwert@gmail.com")
            {
                MobilePhone = "+711111111",
                MainAddress = "kjhdsfkhjskdhjf"
            };
            app.Contacts.Create(contact);
        }
    }
}