using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests: AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            if (app.Contacts.GetContactsQuantityOnPage() == 0)
                app.Contacts.Create(new ContactData("", "", ""));
            
            var newContactDataData = new ContactData("modifiedWerty", "modifiedQwerty", "new.werty.qwert@gmail.com")
            {
                MobilePhone = "+5555",
                MainAddress = "updated mail address"
            };
            app.Contacts.Modify(1, newContactDataData);
        }
    }
}