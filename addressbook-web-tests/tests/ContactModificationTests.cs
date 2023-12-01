using NUnit.Framework;

namespace WebAddressbookTests
{
  [TestFixture]
  public class ContactModificationTests : AuthTestBase
  {
    [Test]
    public void ContactModificationTest()
    {
      // test preparation
      if (app.Contacts.GetContactsCount() == 0)
        app.Contacts.Create(new ContactData("", "", ""));
      var oldContacts = app.Contacts.GetContactsList();

      // action
      var newContactDataData = new ContactData("modifiedWerty", "modifiedQwerty", "new.werty.qwert@gmail.com")
      {
          MobilePhone = "+5555",
          MainAddress = "updated mail address"
      };
      app.Contacts.Modify(0, newContactDataData);

      // verification
      Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());

      var newContacts = app.Contacts.GetContactsList();
      oldContacts[0].LastName = newContactDataData.LastName;
      oldContacts[0].FirstName = newContactDataData.FirstName;

      oldContacts.Sort();
      newContacts.Sort();

      Assert.AreEqual(oldContacts, newContacts);
    }
  }
}