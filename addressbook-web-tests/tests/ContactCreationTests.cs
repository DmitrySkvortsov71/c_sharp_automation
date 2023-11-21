using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests: AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            
            ContactData contact = new ContactData("werty", "qwerty", "werty.qwert@gmail.com")
            {
                MobilePhone = "+711111111",
                MainAddress = "kjhdsfkhjskdhjf"
            };
            
            app.Contacts.Create(contact);
            
            // verification
            List<ContactData> newContacts = app.Contacts.GetContactsList();
            
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            
            Assert.AreEqual(oldContacts, newContacts);
            
            
        }
    }
}