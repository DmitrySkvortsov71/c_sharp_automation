using System.Collections.Generic;
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

            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            
            app.Contacts.Remove(0);
            
            oldContacts.RemoveAt(0);
            List<ContactData> newContacts = app.Contacts.GetContactsList();
            
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}