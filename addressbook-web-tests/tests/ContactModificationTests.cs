using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests: AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            // test preparation
            if (app.Contacts.GetContactsQuantityOnPage() == 0)
                app.Contacts.Create(new ContactData("", "", ""));
            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            
            // action
            var newContactDataData = new ContactData("modifiedWerty", "modifiedQwerty", "new.werty.qwert@gmail.com")
            {
                MobilePhone = "+5555",
                MainAddress = "updated mail address"
            };
            app.Contacts.Modify(0, newContactDataData);
            
            // verification
            List<ContactData> newContacts = app.Contacts.GetContactsList();
            
            oldContacts[0].LastName = newContactDataData.LastName;
            oldContacts[0].FirstName = newContactDataData.FirstName;
            
            oldContacts.Sort();
            newContacts.Sort();
            
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}