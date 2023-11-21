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
            // preparation
            if (app.Contacts.GetContactsQuantityOnPage() == 0)
                app.Contacts.Create(new ContactData("", "", ""));
            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            
            // action
            app.Contacts.Remove(0);
            
            // verification
            List<ContactData> newContacts = app.Contacts.GetContactsList();
            
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}