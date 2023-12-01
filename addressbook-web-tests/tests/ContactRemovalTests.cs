using NUnit.Framework;

namespace WebAddressbookTests
{
  [TestFixture]
  public class ContactRemovalTests : AuthTestBase
  {
    [Test]
    public void ContactRemovalTest()
    {
      // preparation
      if (app.Contacts.GetContactsCount() == 0)
        app.Contacts.Create(new ContactData("", "", ""));
      var oldContacts = app.Contacts.GetContactsList();

      // action
      app.Contacts.Remove(0);
      oldContacts.Sort();

      // verification
      Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());
      var newContacts = app.Contacts.GetContactsList();

      oldContacts.RemoveAt(0);
      newContacts.Sort();

      Assert.AreEqual(oldContacts, newContacts);
    }
  }
}