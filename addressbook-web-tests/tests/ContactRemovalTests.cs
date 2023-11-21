using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            if (app.Contacts.GetContactsQuantityOnPage() == 0)
                app.Contacts.Create(new ContactData("", "", ""));
            
            app.Contacts.Remove(1);
        }
    }
}