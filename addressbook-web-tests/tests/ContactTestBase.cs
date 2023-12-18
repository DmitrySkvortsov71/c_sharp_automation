using NUnit.Framework;

namespace WebAddressbookTests
{
  public class ContactTestBase : AuthTestBase
  {
    [TearDown]
    public void CompareContactsInUiToDb()
    {
      var contactsFromUi = app.Contacts.GetContactsList();
      var contactsFromDb = ContactData.GetAll();

      contactsFromUi.Sort();
      contactsFromDb.Sort();

      Assert.AreEqual(contactsFromUi, contactsFromDb);
    }
  }
}