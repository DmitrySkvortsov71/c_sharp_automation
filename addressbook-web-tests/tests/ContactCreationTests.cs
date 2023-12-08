using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
  [TestFixture]
  public class ContactCreationTests : AuthTestBase
  {
    public static IEnumerable<ContactData> RandomContactDataProvider()
    {
      const int contactsQuantity = 3;
      const int randomStringLenght = 7;
      const int numberMin = 1111111;
      const int numberMax = 9999999;

      var contacts = new List<ContactData>();
      for (var i = 0; i < contactsQuantity; i++)
        contacts.Add(new ContactData(
            GenerateRandomString(randomStringLenght), 
            GenerateRandomString(randomStringLenght), 
            $"{GenerateRandomString(randomStringLenght)}@g.com")
            {
                MobilePhone = GenerateRandomNumber(numberMin, numberMax),
                HomePhone = GenerateRandomNumber(numberMin, numberMax),
                WorkPhone = GenerateRandomNumber(numberMin, numberMax)
            }
        );

      return contacts;
    }

    [Test]
    [TestCaseSource(nameof(RandomContactDataProvider))]
    public void ContactCreationTest(ContactData contact)
    {
      var oldContacts = app.Contacts.GetContactsList();
      

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