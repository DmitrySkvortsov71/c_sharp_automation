using NUnit.Framework;

namespace WebAddressbookTests
{
  [TestFixture]
  public class ContactRemovalTests : ContactTestBase
  {
    [Test]
    public void ContactRemovalTest()
    {
      // preparation
      if (app.Contacts.GetContactsCount() == 0)
        app.Contacts.Create(new ContactData("", "", ""));
      
      // var oldContacts = app.Contacts.GetContactsList();
      var oldContacts = ContactData.GetAll();
      var contactToRemove = oldContacts[0];

      // action
      app.Contacts.Remove(contactToRemove);

      // verification
      Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());
      
      // var newContacts = app.Contacts.GetContactsList();
      var newContacts = ContactData.GetAll();
          
      oldContacts.RemoveAt(0);
      oldContacts.Sort();
      newContacts.Sort();

      Assert.AreEqual(oldContacts, newContacts);
    }
  }
}