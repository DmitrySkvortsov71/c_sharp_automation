using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests: AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            var newContactDataData = new ContactData("modifiedWerty", "modifiedQwerty", "new.werty.qwert@gmail.com")
            {
                MobilePhone = "+5555",
                MainAddress = "updated mail address"
            };
            app.Contacts.Modify(1, newContactDataData);
        }
    }
}