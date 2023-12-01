using NUnit.Framework;

namespace WebAddressbookTests
{
  [TestFixture]
  public class ContactCreationTests : AuthTestBase
  {
    [Test]
    public void ContactCreationTest()
    {
      var oldContacts = app.Contacts.GetContactsList();

      var contact = new ContactData("werty", "qwerty", "werty.qwert@gmail.com")
      {
          MobilePhone = "+711111111",
          MainAddress = "kjhdsfkhjskdhjf"
      };

      app.Contacts.Create(contact);

      // verification
      Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());

      var newContacts = app.Contacts.GetContactsList();

      oldContacts.Add(contact);
      oldContacts.Sort();
      newContacts.Sort();

      Assert.AreEqual(oldContacts, newContacts);
    }
  }
}